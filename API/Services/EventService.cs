using API.Contracts;
using API.DTOs.CompanyParticipants;
using API.DTOs.EmployeeParticipants;
using API.DTOs.Events;
using API.Models;
using API.Utilities.Enums;
using API.Utilities.Handlers;
using API.Utilities.Validations;
using System.Globalization;
using System.Security.Claims;

namespace API.Services;

public class EventService
{
    private readonly IEventRepository _eventRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IEmployeeParticipantRepository _employeeParticipantRepository;
    private readonly ICompanyParticipantRepository _companyParticipantRepository;
    private readonly IEventPaymentRepository _eventPaymentRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public EventService(IEventRepository eventRepository, IHttpContextAccessor httpContextAccessor, IEmployeeParticipantRepository employeeParticipantRepository, ICompanyParticipantRepository companyParticipantRepository, IEventPaymentRepository eventPaymentRepository, ICompanyRepository companyRepository, IEmployeeRepository employeeRepository)
    {
        _eventRepository = eventRepository;
        _companyRepository = companyRepository;
        _employeeRepository = employeeRepository;
        _employeeParticipantRepository = employeeParticipantRepository;
        _companyParticipantRepository = companyParticipantRepository;
        _eventPaymentRepository = eventPaymentRepository;

        _httpContextAccessor = httpContextAccessor;
    }

    public List<GetEventDto>? GetEvents(QueryParamGetEventDto queryParams)
    {
        var userEvents = new List<GetEventDto>();
        var filterEvents = (from e in _eventRepository.GetAll()
                            join c in _companyRepository.GetAll()
                            on e.CreatedBy equals c.Guid
                            select new GetEventDto
                            {
                                Guid = e.Guid,
                                Name = e.Name,
                                Description = e.Description,
                                Thumbnail = e.Thumbnail,
                                Visibility = e.IsPublished == true ? "public" : "private",
                                Category = e.Category,
                                PlaceType = e.Status == EventStatus.Offline ? "offline" : "online",
                                Payment = e.IsPaid == true ? "paid" : "free",
                                Price = e.Price,
                                Quota = e.Quota,
                                Joined = e.UsedQuota,
                                StartDate = e.StartDate.ToString("dd MMMM yyyy, HH:mm WIB"),
                                EndDate = e.EndDate.ToString("dd MMMM yyyy, HH:mm WIB"),
                                Organizer = c.Name,
                                Place = e.Place,
                                PublicationStatus = e.IsActive == true ? "published" : "draft"
                            }).ToList();

        if (filterEvents is null)
        {
            return null;
        }

        var publicationStatus = queryParams.publication_status?.ToLower();
        var visibility = queryParams.visibility?.ToLower();
        var placeType = queryParams.place_type?.ToLower();
        var sortBy = queryParams.sort_by?.ToLower();

        var publicationStatusValues = new List<string>() { "all", "published", "draft" };
        var visibilityValues = new List<string>() { "all", "public", "private" };
        var placeTypeValues = new List<string>() { "all", "offline", "online" };

        if (publicationStatusValues.Contains(publicationStatus))
        {
            if (publicationStatus != "all")
            {
                filterEvents = filterEvents.Where(e => e.PublicationStatus == publicationStatus).ToList();
            }
        }

        if (visibilityValues.Contains(visibility))
        {
            if (visibility != "all")
            {
                filterEvents = filterEvents.Where(e => e.Visibility == visibility).ToList();
            }
        }

        if (placeTypeValues.Contains(placeType))
        {
            if (placeType != "all")
            {
                filterEvents = filterEvents.Where(e => e.PlaceType == placeType).ToList();
            }
        }

        string format = "dd MMMM yyyy, HH:mm 'WIB'";
        if (sortBy == "older")
        {
            filterEvents = filterEvents.OrderByDescending(e => DateTime.ParseExact(e.StartDate, format, CultureInfo.InvariantCulture)).ToList();
        }

        if (sortBy == "newest")
        {
            filterEvents = filterEvents.OrderBy(e => DateTime.ParseExact(e.StartDate, format, CultureInfo.InvariantCulture)).ToList();
        }

        // authorization
        var claimUser = _httpContextAccessor.HttpContext?.User;

        var userRole = claimUser?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        var accountGuid = claimUser?.Claims?.FirstOrDefault(x => x.Type == "Guid")?.Value;

        if (userRole == nameof(RoleLevel.Company))
        {
            var company = _companyRepository.GetAll().FirstOrDefault(c => c.AccountGuid == Guid.Parse(accountGuid!));

            if (company == null)
            {
                return null;
            }

            filterEvents = filterEvents.Where(e =>
            {
                if (e.Organizer == company.Name)
                {
                    return true;
                }
                else if (e.Organizer != company.Name && e.PublicationStatus == "draft")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }).ToList();

            var companyParticipants = _companyParticipantRepository.GetAll();

            foreach (var filterEvent in filterEvents)
            {
                if (companyParticipants.FirstOrDefault(cp => cp.CompanyGuid == company.Guid && cp.EventGuid == filterEvent.Guid) is not null || filterEvent.Organizer == company.Name)
                {
                    userEvents.Add(filterEvent);
                }
            }

        }
        else if (userRole == nameof(RoleLevel.Employee))
        {
            var employee = _employeeRepository.GetAll().FirstOrDefault(c => c.AccountGuid == Guid.Parse(accountGuid!));

            if (employee is null)
            {
                return null;
            }
            filterEvents = filterEvents.Where(e => e.PublicationStatus == "published").ToList();

            var employeeParticipants = _employeeParticipantRepository.GetAll();

            foreach (var filterEvent in filterEvents)
            {
                if (employeeParticipants.FirstOrDefault(ep => ep.EmployeeGuid == employee.Guid && ep.EventGuid == filterEvent.Guid) is not null)
                {
                    userEvents.Add(filterEvent);
                }
            }

        }
        else
        {
            return null;
        }

        return userEvents;
    }

    public GetEventMasterDto? GetEvent(Guid guid, string? usedfor)
    {
        var singleEvent = _eventRepository.GetByGuid(guid);

        if (singleEvent is null)
        {
            return null;
        }

        var makerEvent = _companyRepository.GetAll().FirstOrDefault(c => c.Guid == singleEvent.CreatedBy);

        if (makerEvent is null)
        {
            return null;
        }

        var detailsEvent = new GetEventMasterDto
        {
            Guid = singleEvent.Guid,
            Name = singleEvent.Name,
            Thumbnail = singleEvent.Thumbnail,
            Description = singleEvent.Description,
            Category = singleEvent.Category,
            Organizer = makerEvent.Name,
            Payment = singleEvent.IsPaid == true ? "paid" : "free",
            Price = singleEvent.Price,
            Place = singleEvent.Place,
            PlaceType = singleEvent.Status == 0 ? "offline" : "online",
            StartDate = singleEvent.StartDate.ToString("dd MMMM yyyy, HH:mm WIB"),
            EndDate = singleEvent.EndDate.ToString("dd MMMM yyyy, HH:mm WIB"),
            Quota = singleEvent.Quota,
            Joined = singleEvent.UsedQuota,
            Visibility = singleEvent.IsPublished == true ? "public" : "private",
            PublicationStatus = singleEvent.IsActive == true ? "published" : "draft",

        };


        var claimUser = _httpContextAccessor.HttpContext?.User;

        var userRole = claimUser?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        var accountGuid = claimUser?.Claims?.FirstOrDefault(x => x.Type == "Guid")?.Value;

        var employees = _employeeRepository.GetAll();

        if (userRole == nameof(RoleLevel.Company))
        {
            var company = _companyRepository.GetAll().FirstOrDefault(c => c.AccountGuid == Guid.Parse(accountGuid!));

            if (company == null)
            {
                return null;
            }

            var companies = _companyRepository.GetAll();
            var employeeParticipantsEvent = new List<GetEmployeeParticipantDto>();

            var employeeParticipants = _employeeParticipantRepository.GetAll();

            // jika company adalah si pembuat event
            if (singleEvent.CreatedBy == company.Guid)
            {
                var companyParticipantsEvent = new List<GetCompanyParticipantDto>();

                companyParticipantsEvent = _companyParticipantRepository.GetAll().Where(cp => cp.EventGuid == singleEvent.Guid && cp.CompanyGuid != company.Guid).Select(cp =>
                {
                    var companyName = companies.FirstOrDefault(c => c.Guid == cp.CompanyGuid);
                    var invitataionStatus = "";

                    if (cp.Status == InviteStatusLevel.Pending) invitataionStatus = "pending";
                    if (cp.Status == InviteStatusLevel.Accepted) invitataionStatus = "accepted";
                    if (cp.Status == InviteStatusLevel.Rejected) invitataionStatus = "rejected";


                    return new GetCompanyParticipantDto
                    {
                        Guid = cp.Guid,
                        EventName = singleEvent.Name,
                        CompanyGuid = cp.CompanyGuid,
                        CompanyName = companyName?.Name ?? "",
                        InvitationStatus = invitataionStatus,
                        IsPresent = cp.IsPresent,
                    };
                }).ToList();

                var employeeParticipantsEvent2 = employeeParticipants.Where(ep =>
                {
                    var employee = employees.FirstOrDefault(e => e.Guid == ep.EmployeeGuid);


                    // jika event maker mengedit event, maka hanya bisa mengedit employeenya saja
                    if (usedfor == "edit")
                    {
                        var isEmployeeCompany = employee?.CompanyGuid == company.Guid;

                        return ep.EventGuid == singleEvent.Guid && isEmployeeCompany;
                    }

                    return ep.EventGuid == singleEvent.Guid;
                    //return true;

                }).Select(ep =>
                {
                    var employee = employees.FirstOrDefault(e => e.Guid == ep.EmployeeGuid);
                    var employeeName = employee?.FullName;

                    var companyEmployeeName = companies.FirstOrDefault(c => c.Guid == employee?.CompanyGuid)?.Name;

                    var invitataionStatus = "";

                    if (ep.Status == InviteStatusLevel.Pending) invitataionStatus = "pending";
                    if (ep.Status == InviteStatusLevel.Accepted) invitataionStatus = "accepted";
                    if (ep.Status == InviteStatusLevel.Rejected) invitataionStatus = "rejected";

                    return new GetEmployeeParticipantDto
                    {
                        Guid = ep.Guid,
                        EventName = singleEvent.Name,
                        EmployeeGuid = ep.EmployeeGuid,
                        EmployeeName = employeeName ?? "",
                        InvitationStatus = invitataionStatus,
                        CompanyName = companyEmployeeName ?? "",
                        IsPresent = ep.IsPresent,
                    };
                }).ToList();

                detailsEvent.CompanyParticipants = companyParticipantsEvent;
                detailsEvent.EmployeeParticipants = employeeParticipantsEvent2;
            }
            else
            {
                employeeParticipantsEvent = employeeParticipants.Where(ep =>
                {
                    var employee = employees.FirstOrDefault(e => e.Guid == ep.EmployeeGuid);
                    var isEmployeeCompany = employee?.CompanyGuid == company.Guid;

                    return ep.EventGuid == singleEvent.Guid && isEmployeeCompany;

                }).Select(ep =>
                {
                    var employee = employees.FirstOrDefault(e => e.Guid == ep.EmployeeGuid);
                    var employeeName = employee?.FullName;

                    var companyEmployeeName = companies.FirstOrDefault(c => c.Guid == employee?.CompanyGuid)?.Name;

                    var invitataionStatus = "";

                    if (ep.Status == InviteStatusLevel.Pending) invitataionStatus = "pending";
                    if (ep.Status == InviteStatusLevel.Accepted) invitataionStatus = "accepted";
                    if (ep.Status == InviteStatusLevel.Rejected) invitataionStatus = "rejected";

                    return new GetEmployeeParticipantDto
                    {
                        Guid = ep.Guid,
                        EventName = singleEvent.Name,
                        EmployeeGuid = ep.EmployeeGuid,
                        EmployeeName = employeeName ?? "",
                        CompanyName = companyEmployeeName ?? "",
                        InvitationStatus = invitataionStatus,
                        IsPresent = ep.IsPresent,
                    };
                }).ToList();

                var paymentGuid = _eventPaymentRepository.GetAll().FirstOrDefault(ep => ep.EventGuid == singleEvent.Guid && ep.AccountGuid == company.AccountGuid)?.Guid;

                detailsEvent.PaymentGuid = paymentGuid;

                detailsEvent.EmployeeParticipants = employeeParticipantsEvent;
            }
        }
        else if (userRole == nameof(RoleLevel.Employee))
        {
            var employee = employees.FirstOrDefault(e => e.AccountGuid == Guid.Parse(accountGuid!));

            if (employee is null)
            {
                return null;
            }

            var paymentGuid = _eventPaymentRepository.GetAll().FirstOrDefault(ep => ep.EventGuid == singleEvent.Guid && ep.AccountGuid == employee.AccountGuid)?.Guid;

            detailsEvent.PaymentGuid = paymentGuid;
        }
        else
        {
            return null;
        }

        return detailsEvent;
    }

    public async Task<int> CreateEvent(CreateEventDto createEventDto)
    {
        var imageUrl = "";
        if (createEventDto.ThumbnailFile != null)
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\events\thumbnails");

            if (!Directory.Exists(folderPath))
            {
                try
                {
                    Directory.CreateDirectory(folderPath);
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }

            var size = createEventDto.ThumbnailFile.Length;

            // jika ukuran gambar lebih dari 2mb
            if (size > 2000000)
            {
                return -2;
            }

            bool isImage = FileValidation.IsValidImageExtension(createEventDto.ThumbnailFile);

            if (!isImage)
            {
                return -3;
            }

            var randomName = GenerateHandler.GenerateRandomString();
            var fileName = randomName + createEventDto.ThumbnailFile.FileName;
            imageUrl = $"images/events/thumbnails/{fileName}";

            var filePath = $"{folderPath}\\{fileName}";

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await createEventDto.ThumbnailFile.CopyToAsync(stream);
                }
            }
            catch
            {
                return -3;
            }
        }


        var claimUser = _httpContextAccessor.HttpContext?.User;

        var userRole = claimUser?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        var accountGuid = claimUser?.Claims?.FirstOrDefault(x => x.Type == "Guid")?.Value;
        Console.WriteLine("Hello World 1");
        if (accountGuid is null)
        {
            return 0;
        }

        var company = _companyRepository.GetAll().FirstOrDefault(c => c.AccountGuid == Guid.Parse(accountGuid));
        Console.WriteLine("Hello World 2");

        if (company is null)
        {
            return 0;
        }

        var eventModel = new Event
        {
            Guid = new Guid(),
            Name = createEventDto.Name,
            Thumbnail = imageUrl,
            Description = createEventDto.Description,
            IsPublished = createEventDto.Visibility == "public" ? true : false,
            IsPaid = createEventDto.Payment == "paid" ? true : false,
            Price = createEventDto.Price,
            Category = createEventDto.Category!,
            Status = createEventDto.PlaceType == "offline" ? EventStatus.Offline : EventStatus.Online,
            StartDate = createEventDto.StartDate,
            EndDate = createEventDto.EndDate,
            Quota = createEventDto.Quota,
            Place = createEventDto.Place,
            CreatedBy = company.Guid
        };

        var created = _eventRepository.Create(eventModel);
        if (created is null)
        {
            return 0;
        }

        return 1;
    }

    public EventsDto? UpdateEvent(EventsDto eventsDto)
    {
        var singleEvent = _eventRepository.GetByGuid(eventsDto.Guid);
        if (singleEvent == null)
        {
            return null;
        }

        var eventModel = new Event
        {
            Guid = eventsDto!.Guid,
            Name = eventsDto.Name!,
            Thumbnail = eventsDto.Thumbnail,
            Description = eventsDto.Description!,
            IsPublished = (bool)eventsDto.IsPublished!,
            IsPaid = (bool)eventsDto.IsPaid!,
            Price = eventsDto.Price,
            Category = eventsDto.Category!,
            Status = eventsDto.Status,
            StartDate = eventsDto.StartDate,
            EndDate = eventsDto.EndDate,
            Quota = (int)eventsDto.Quota!,
            Place = eventsDto.Place!,
            CreatedBy = eventsDto.CreatedBy
        };

        var isUpdate = _eventRepository.Update(eventModel);
        if (!isUpdate)
        {
            return null;
        }

        var updatedEvent = new EventsDto
        {
            Guid = eventModel!.Guid,
            Name = eventModel.Name!,
            Thumbnail = eventModel.Thumbnail,
            Description = eventModel.Description!,
            IsPublished = (bool)eventModel.IsPublished!,
            IsPaid = (bool)eventModel.IsPaid!,
            Price = eventModel.Price,
            Category = eventModel.Category!,
            Status = eventModel.Status,
            StartDate = eventModel.StartDate,
            EndDate = eventModel.EndDate,
            Quota = (int)eventModel.Quota!,
            Place = eventModel.Place!,
            CreatedBy = eventModel.CreatedBy
        };

        return updatedEvent;
    }

    public EventsDto? DeleteEvent(Guid guid)
    {
        var singleEvent = _eventRepository.GetByGuid(guid);
        if (singleEvent == null)
        {
            return null;
        }

        var isDelete = _eventRepository.Delete(singleEvent!);
        if (!isDelete)
        {
            return null;
        }

        var deletedEvent = new EventsDto
        {
            Guid = singleEvent.Guid,
            Name = singleEvent.Name!,
            Thumbnail = singleEvent.Thumbnail,
            Description = singleEvent.Description!,
            IsPublished = (bool)singleEvent.IsPublished!,
            IsPaid = (bool)singleEvent.IsPaid!,
            Price = singleEvent.Price,
            Category = singleEvent.Category!,
            Status = singleEvent.Status,
            StartDate = singleEvent.StartDate,
            EndDate = singleEvent.EndDate,
            Quota = (int)singleEvent.Quota!,
            Place = singleEvent.Place!,
            CreatedBy = singleEvent.CreatedBy
        };

        return deletedEvent;
    }


    public List<GetEventDto>? GetInternalEvents(QueryParamGetEventDto queryParams)
    {
        var claimUser = _httpContextAccessor.HttpContext?.User;

        var userRole = claimUser?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        var accountGuid = claimUser?.Claims?.FirstOrDefault(x => x.Type == "Guid")?.Value;

        if (userRole == nameof(RoleLevel.Company))
        {
            var company = _companyRepository.GetAll().FirstOrDefault(c => c.AccountGuid == Guid.Parse(accountGuid!));

            if (company == null)
            {
                return null;
            }

            var internalEvents = new List<GetEventDto>();

            var filterEvents = (from e in _eventRepository.GetAll()
                                join c in _companyRepository.GetAll()
                                on e.CreatedBy equals c.Guid
                                where e.CreatedBy == company.Guid
                                select new GetEventDto
                                {
                                    Guid = e.Guid,
                                    Name = e.Name,
                                    Description = e.Description,
                                    Thumbnail = e.Thumbnail,
                                    Visibility = e.IsPublished == true ? "public" : "private",
                                    Category = e.Category,
                                    PlaceType = e.Status == EventStatus.Offline ? "offline" : "online",
                                    Payment = e.IsPaid == true ? "paid" : "free",
                                    Price = e.Price,
                                    Quota = e.Quota,
                                    Joined = e.UsedQuota,
                                    StartDate = e.StartDate.ToString("dd MMMM yyyy, HH:mm WIB"),
                                    EndDate = e.EndDate.ToString("dd MMMM yyyy, HH:mm WIB"),
                                    Organizer = c.Name,
                                    Place = e.Place,
                                    PublicationStatus = e.IsActive == true ? "published" : "draft"
                                }).ToList();

            if (filterEvents is null)
            {
                return null;
            }

            var publicationStatus = queryParams.publication_status?.ToLower() ?? "";
            var visibility = queryParams.visibility?.ToLower() ?? "";
            var placeType = queryParams.place_type?.ToLower() ?? "";
            var sortBy = queryParams.sort_by?.ToLower() ?? "";

            var publicationStatusValues = new List<string>() { "all", "published", "draft" };
            var visibilityValues = new List<string>() { "all", "public", "private" };
            var placeTypeValues = new List<string>() { "all", "offline", "online" };

            if (publicationStatusValues.Contains(publicationStatus))
            {
                if (publicationStatus != "all")
                {
                    filterEvents = filterEvents.Where(e => e.PublicationStatus == publicationStatus).ToList();
                }
            }

            if (visibilityValues.Contains(visibility))
            {
                if (visibility != "all")
                {
                    filterEvents = filterEvents.Where(e => e.Visibility == visibility).ToList();
                }
            }

            if (placeTypeValues.Contains(placeType))
            {
                if (placeType != "all")
                {
                    filterEvents = filterEvents.Where(e => e.PlaceType == placeType).ToList();
                }
            }

            string format = "dd MMMM yyyy, HH:mm 'WIB'";
            if (sortBy == "older")
            {
                filterEvents = filterEvents.OrderByDescending(e => DateTime.ParseExact(e.StartDate, format, CultureInfo.InvariantCulture)).ToList();
            }

            if (sortBy == "newest")
            {
                filterEvents = filterEvents.OrderBy(e => DateTime.ParseExact(e.StartDate, format, CultureInfo.InvariantCulture)).ToList();
            }

            internalEvents = filterEvents;

            return internalEvents;
        }
        else
        {
            return null;
        }



    }

    //public List<EventsDto>? GetExternalEvents(string type = "")
    //{
    //    var claimUser = _httpContextAccessor.HttpContext?.User;

    //    var userRole = claimUser?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
    //    var accountGuid = claimUser?.Claims?.FirstOrDefault(x => x.Type == "Guid")?.Value;

    //    var externalEvents = new List<EventsDto>();

    //    if (userRole == nameof(RoleLevel.Company))
    //    {
    //        var company = _companyRepository.GetAll().FirstOrDefault(c => c.AccountGuid == Guid.Parse(accountGuid!));

    //        if (company != null)
    //        {
    //            var getExternalEvents = new List<Event>();

    //            if (string.Equals(type, nameof(EventTypeEnum.Public), StringComparison.OrdinalIgnoreCase))
    //            {
    //                getExternalEvents = _eventRepository.GetAll().Where(ev => ev.CreatedBy != company.Guid && ev.IsPublished is true && ev.IsActive is true).ToList();

    //            }
    //            else if (string.Equals(type, nameof(EventTypeEnum.Personal), StringComparison.OrdinalIgnoreCase))
    //            {
    //                getExternalEvents = _eventRepository.GetAll().Where(ev => ev.CreatedBy != company.Guid && ev.IsPublished is false && ev.IsActive is true).ToList();
    //            }
    //            else
    //            {
    //                getExternalEvents = _eventRepository.GetAll().Where(ev => ev.CreatedBy != company.Guid && ev.IsActive is true).ToList();
    //            }

    //            var externalEventsIsActive = getExternalEvents.Select(ev => new EventsDto
    //            {
    //                Guid = ev.Guid,
    //                Name = ev.Name,
    //                Description = ev.Description,
    //                Category = ev.Category,
    //                CreatedBy = ev.CreatedBy,
    //                StartDate = ev.StartDate,
    //                EndDate = ev.EndDate,
    //                IsActive = ev.IsActive,
    //                IsPaid = ev.IsPaid,
    //                IsPublished = ev.IsPublished,
    //                Status = ev.Status,
    //                Place = ev.Place,
    //                Price = ev.Price,
    //                Quota = ev.Quota,
    //                Thumbnail = ev.Thumbnail,
    //                UsedQuota = ev.UsedQuota,
    //            }).ToList();

    //            var companyParticipants = _companyParticipantRepository.GetAll();

    //            foreach (var externalEvent in externalEventsIsActive)
    //            {
    //                if (companyParticipants.FirstOrDefault(cp => cp.CompanyGuid == company.Guid && cp.EventGuid == externalEvent.Guid) is not null)
    //                {
    //                    externalEvents.Add(externalEvent);
    //                }
    //            }
    //        }
    //        else
    //        {
    //            return null;
    //        }
    //    }
    //    else if (userRole == nameof(RoleLevel.Employee))
    //    {
    //        var employee = _employeeRepository.GetAll().FirstOrDefault(e => e.AccountGuid == Guid.Parse(accountGuid!));

    //        if (employee is not null)
    //        {
    //            var getExternalEvents = new List<Event>();

    //            if (string.Equals(type, nameof(EventTypeEnum.Public), StringComparison.OrdinalIgnoreCase))
    //            {
    //                getExternalEvents = _eventRepository.GetAll().Where(ev => ev.CreatedBy != employee.CompanyGuid && ev.IsPublished is true && ev.IsActive is true).ToList();

    //            }
    //            else if (string.Equals(type, nameof(EventTypeEnum.Personal), StringComparison.OrdinalIgnoreCase))
    //            {
    //                getExternalEvents = _eventRepository.GetAll().Where(ev => ev.CreatedBy != employee.CompanyGuid && ev.IsPublished is false && ev.IsActive is true).ToList();
    //            }
    //            else
    //            {
    //                getExternalEvents = _eventRepository.GetAll().Where(ev => ev.CreatedBy != employee.CompanyGuid && ev.IsActive is true).ToList();
    //            }

    //            var externalEventsIsActive = getExternalEvents.Select(ev => new EventsDto
    //            {
    //                Guid = ev.Guid,
    //                Name = ev.Name,
    //                Description = ev.Description,
    //                Category = ev.Category,
    //                CreatedBy = ev.CreatedBy,
    //                StartDate = ev.StartDate,
    //                EndDate = ev.EndDate,
    //                IsActive = ev.IsActive,
    //                IsPaid = ev.IsPaid,
    //                IsPublished = ev.IsPublished,
    //                Status = ev.Status,
    //                Place = ev.Place,
    //                Price = ev.Price,
    //                Quota = ev.Quota,
    //                Thumbnail = ev.Thumbnail,
    //                UsedQuota = ev.UsedQuota,
    //            }).ToList();

    //            var employeeParticipants = _employeeParticipantRepository.GetAll();

    //            foreach (var externalEvent in externalEventsIsActive)
    //            {
    //                if (employeeParticipants.FirstOrDefault(ep => ep.EmployeeGuid == employee.Guid && ep.EventGuid == externalEvent.Guid) is not null)
    //                {
    //                    externalEvents.Add(externalEvent);
    //                }
    //            }
    //        }
    //        else
    //        {
    //            return null;
    //        }

    //    }

    //    return externalEvents;
    //}

    //public List<EventsDto>? GetPublicEvents()
    //{
    //    var claimUser = _httpContextAccessor.HttpContext?.User;

    //    var userRole = claimUser?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
    //    var accountGuid = claimUser?.Claims?.FirstOrDefault(x => x.Type == "Guid")?.Value;

    //    var publicEventsParticipant = new List<EventsDto>();
    //    var companies = _companyRepository.GetAll();

    //    var publicEvents = _eventRepository.GetAll().Where(ev => ev.IsPublished is true && ev.IsActive is true).Select(e =>
    //    {
    //        var makerEvent = companies.FirstOrDefault(c => c.Guid == e.CreatedBy);

    //        return new EventsDto
    //        {
    //            Guid = e.Guid,
    //            Name = e.Name,
    //            Description = e.Description,
    //            Thumbnail = e.Thumbnail,
    //            StartDate = e.StartDate,
    //            EndDate = e.EndDate,
    //            IsPublished = e.IsPublished,
    //            IsActive = e.IsActive,
    //            IsPaid = e.IsPaid,
    //            Price = e.Price,
    //            Status = e.Status,
    //            Place = e.Place,
    //            Quota = e.Quota,
    //            UsedQuota = e.UsedQuota,
    //            Category = e.Category,
    //            CreatedBy = e.CreatedBy,
    //            MakerName = makerEvent?.Name
    //        };
    //    });

    //    if (userRole == nameof(RoleLevel.Company))
    //    {
    //        var company = _companyRepository.GetAll().FirstOrDefault(c => c.AccountGuid == Guid.Parse(accountGuid!));

    //        if (company is null)
    //        {
    //            return null;
    //        }

    //        var companyParticipants = _companyParticipantRepository.GetAll();

    //        foreach (var publicEvent in publicEvents)
    //        {
    //            if (companyParticipants.FirstOrDefault(cp => cp.CompanyGuid == company.Guid && cp.EventGuid == publicEvent.Guid) is not null || publicEvent.CreatedBy == company.Guid)
    //            {
    //                publicEventsParticipant.Add(publicEvent);
    //            }
    //        }
    //    }
    //    else if (userRole == nameof(RoleLevel.Employee))
    //    {
    //        var employee = _employeeRepository.GetAll().FirstOrDefault(e => e.AccountGuid == Guid.Parse(accountGuid!));

    //        if (employee is null)
    //        {
    //            return null;
    //        }

    //        var employeeParticipants = _employeeParticipantRepository.GetAll();

    //        foreach (var publicEvent in publicEvents)
    //        {
    //            if (employeeParticipants.FirstOrDefault(ep => ep.EmployeeGuid == employee.Guid && ep.EventGuid == publicEvent.Guid) is not null)
    //            {
    //                publicEventsParticipant.Add(publicEvent);
    //            }
    //        }
    //    }
    //    else
    //    {
    //        return null;
    //    }

    //    return publicEventsParticipant;
    //}

    //public List<EventsDto>? GetPersonalEvents()
    //{
    //    var claimUser = _httpContextAccessor.HttpContext?.User;

    //    var userRole = claimUser?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
    //    var accountGuid = claimUser?.Claims?.FirstOrDefault(x => x.Type == "Guid")?.Value;

    //    var publicEventsParticipant = new List<EventsDto>();
    //    var companies = _companyRepository.GetAll();

    //    var publicEvents = _eventRepository.GetAll().Where(ev => ev.IsPublished is false && ev.IsActive is true).Select(e =>
    //    {
    //        var makerEvent = companies.FirstOrDefault(c => c.Guid == e.CreatedBy);

    //        return new EventsDto
    //        {
    //            Guid = e.Guid,
    //            Name = e.Name,
    //            Description = e.Description,
    //            Thumbnail = e.Thumbnail,
    //            StartDate = e.StartDate,
    //            EndDate = e.EndDate,
    //            IsPublished = e.IsPublished,
    //            IsActive = e.IsActive,
    //            IsPaid = e.IsPaid,
    //            Price = e.Price,
    //            Status = e.Status,
    //            Place = e.Place,
    //            Quota = e.Quota,
    //            UsedQuota = e.UsedQuota,
    //            Category = e.Category,
    //            CreatedBy = e.CreatedBy,
    //            MakerName = makerEvent?.Name
    //        };
    //    });

    //    if (userRole == nameof(RoleLevel.Company))
    //    {
    //        var company = _companyRepository.GetAll().FirstOrDefault(c => c.AccountGuid == Guid.Parse(accountGuid!));

    //        if (company is null)
    //        {
    //            return null;
    //        }

    //        var companyParticipants = _companyParticipantRepository.GetAll();

    //        foreach (var publicEvent in publicEvents)
    //        {
    //            if (companyParticipants.FirstOrDefault(cp => cp.CompanyGuid == company.Guid && cp.EventGuid == publicEvent.Guid) is not null || publicEvent.CreatedBy == company.Guid)
    //            {
    //                publicEventsParticipant.Add(publicEvent);
    //            }
    //        }
    //    }
    //    else if (userRole == nameof(RoleLevel.Employee))
    //    {
    //        var employee = _employeeRepository.GetAll().FirstOrDefault(e => e.AccountGuid == Guid.Parse(accountGuid!));

    //        if (employee is null)
    //        {
    //            return null;
    //        }

    //        var employeeParticipants = _employeeParticipantRepository.GetAll();

    //        foreach (var publicEvent in publicEvents)
    //        {
    //            if (employeeParticipants.FirstOrDefault(ep => ep.EmployeeGuid == employee.Guid && ep.EventGuid == publicEvent.Guid) is not null)
    //            {
    //                publicEventsParticipant.Add(publicEvent);
    //            }
    //        }
    //    }
    //    else
    //    {
    //        return null;
    //    }

    //    return publicEventsParticipant;
    //}


    public List<TicketDto>? GetTickets(QueryParamGetTicketDto queryParams)
    {
        var claimUser = _httpContextAccessor.HttpContext?.User;

        var userRole = claimUser?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        var accountGuid = claimUser?.Claims?.FirstOrDefault(x => x.Type == "Guid")?.Value;

        var userTickets = new List<TicketDto>();
        var events = _eventRepository.GetAll();

        var time = queryParams.time;
        var sortBy = queryParams.sort_by;


        // time values : "all", "coming-soon", "now", "past"
        // sortby values : "newest", "older"

        var now = DateTime.Now;

        if (time == "coming-soon")
        {
            events = events.Where(e => e.StartDate > now).ToList();
        }

        if (time == "now")
        {
            events = events.Where(e => e.StartDate < now && e.EndDate > now).ToList();
        }

        if (time == "past")
        {
            events = events.Where(e => e.EndDate < now).ToList();
        }

        if (sortBy == "newest")
        {
            events = events.OrderBy(e => e.StartDate).ToList();
        }

        if (sortBy == "older")
        {
            events = events.OrderByDescending(e => e.StartDate).ToList();
        }

        events = events.Where(e => e.IsActive == true).ToList();

        if (userRole == nameof(RoleLevel.Company))
        {
            var company = _companyRepository.GetAll().FirstOrDefault(c => c.AccountGuid == Guid.Parse(accountGuid!));

            if (company is null)
            {
                return null;
            }

            var companyParticipants = _companyParticipantRepository.GetAll();

            foreach (var e in events)
            {
                var companyAcceptedEvent = companyParticipants.FirstOrDefault(cp => cp.CompanyGuid == company.Guid && cp.EventGuid == e.Guid && cp.Status == InviteStatusLevel.Accepted);

                if (companyAcceptedEvent is not null)
                {
                    var ticketCode = $"{Math.Abs(e.Guid.GetHashCode())}-{Math.Abs(companyAcceptedEvent.Guid.GetHashCode())}";
                    var ticket = new TicketDto
                    {
                        EventName = e.Name,
                        ParticipantName = company.Name,
                        Place = e.Place,
                        StartDate = e.StartDate.ToString("dd MMMM yyyy, HH:mm WIB"),
                        TicketCode = ticketCode
                    };

                    userTickets.Add(ticket);
                }
            }
        }
        else if (userRole == nameof(RoleLevel.Employee))
        {
            var employee = _employeeRepository.GetAll().FirstOrDefault(e => e.AccountGuid == Guid.Parse(accountGuid!));

            if (employee is null)
            {
                return null;
            }

            var employeeParticipants = _employeeParticipantRepository.GetAll();

            foreach (var e in events)
            {
                var employeeAcceptedEvent = employeeParticipants.FirstOrDefault(ep => ep.EmployeeGuid == employee.Guid && ep.EventGuid == e.Guid && ep.Status == InviteStatusLevel.Accepted);

                if (employeeAcceptedEvent is not null)
                {
                    var ticketCode = $"{Math.Abs(e.Guid.GetHashCode())}-{Math.Abs(employeeAcceptedEvent.Guid.GetHashCode())}";
                    var ticket = new TicketDto
                    {
                        EventName = e.Name,
                        ParticipantName = employee.FullName,
                        Place = e.Place,
                        StartDate = e.StartDate.ToString("dd MMMM yyyy, HH:mm WIB"),
                        TicketCode = ticketCode
                    };

                    userTickets.Add(ticket);
                }
            }
        }
        else
        {
            return null;
        }

        return userTickets;
    }
}



