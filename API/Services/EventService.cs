using API.Contracts;
using API.DTOs.CompanyParticipants;
using API.DTOs.EmployeeParticipants;
using API.DTOs.EventPayments;
using API.DTOs.Events;
using API.Models;
using API.Utilities.Enums;
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

        //if (publicationStatusValues.Contains(publicationStatus) && visibilityValues.Contains(visibility) && publicationStatusValues.Contains(publicationStatus))
        //{

        //    if (publicationStatus != "all" && visibility != "all" && placeType != "all")
        //    {
        //        filterEvents = filterEvents.Where(e => e.PublicationStatus == publicationStatus && e.Visibility == visibility && e.PlaceType == placeType).ToList();
        //    }

        //    if (publicationStatus != "all" && visibility != "all")
        //    {
        //        filterEvents = filterEvents.Where(e => e.PublicationStatus == publicationStatus && e.Visibility == visibility).ToList();
        //    }

        //    if (publicationStatus != "all")
        //    {
        //        filterEvents = filterEvents.Where(e => e.PublicationStatus == publicationStatus).ToList();
        //    }
        //}

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

    public EventsDto? GetEvent(Guid guid)
    {
        var singleEvent = _eventRepository.GetByGuid(guid);
        if (singleEvent == null)
        {
            return null;
        }

        var e = singleEvent;

        var events = new EventsDto
        {
            Guid = e!.Guid,
            Name = e.Name,
            Thumbnail = e.Thumbnail,
            Description = e.Description,
            IsPublished = e.IsPublished,
            IsPaid = e.IsPaid,
            Price = e.Price,
            Category = e.Category,
            Status = e.Status,
            StartDate = e.StartDate,
            EndDate = e.EndDate,
            Quota = e.Quota,
            Place = e.Place,
            CreatedBy = e.CreatedBy
        };

        return events;
    }

    public EventsDto? CreateEvent(CreateEventDto createEventDto)
    {
        var eventModel = new Event
        {
            Guid = new Guid(),
            Name = createEventDto.Name!,
            Thumbnail = createEventDto.Thumbnail,
            Description = createEventDto.Description!,
            IsPublished = (bool)createEventDto.IsPublished!,
            IsPaid = (bool)createEventDto.IsPaid!,
            Price = createEventDto.Price,
            Category = createEventDto.Category!,
            Status = createEventDto.Status,
            StartDate = createEventDto.StartDate,
            EndDate = createEventDto.EndDate,
            Quota = (int)createEventDto.Quota!,
            Place = createEventDto.Place!,
            CreatedBy = createEventDto.CreatedBy
        };

        var created = _eventRepository.Create(eventModel);
        if (created is null)
        {
            return null;
        }


        var createdEvent = new EventsDto
        {
            Guid = eventModel.Guid,
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

        return createdEvent;
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


    public List<EventsDto>? GetInternalEvents(string type = "")
    {
        var claimUser = _httpContextAccessor.HttpContext?.User;

        var userRole = claimUser?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        var accountGuid = claimUser?.Claims?.FirstOrDefault(x => x.Type == "Guid")?.Value;

        var internalEvents = new List<EventsDto>();

        if (userRole == nameof(RoleLevel.Company))
        {
            var company = _companyRepository.GetAll().FirstOrDefault(c => c.AccountGuid == Guid.Parse(accountGuid!));

            if (company != null)
            {
                var getInternalEvents = new List<Event>();

                if (string.Equals(type, nameof(EventTypeEnum.Public), StringComparison.OrdinalIgnoreCase))
                {
                    getInternalEvents = _eventRepository.GetEventsByCreatedBy(company.Guid).Where(ev => ev.IsPublished is true).ToList();

                }
                else if (string.Equals(type, nameof(EventTypeEnum.Personal), StringComparison.OrdinalIgnoreCase))
                {
                    getInternalEvents = _eventRepository.GetEventsByCreatedBy(company.Guid).Where(ev => ev.IsPublished is false).ToList();
                }
                else
                {
                    getInternalEvents = _eventRepository.GetEventsByCreatedBy(company.Guid).ToList();
                }

                internalEvents = getInternalEvents.Select(ev => new EventsDto
                {
                    Guid = ev.Guid,
                    Name = ev.Name,
                    Description = ev.Description,
                    Category = ev.Category,
                    CreatedBy = ev.CreatedBy,
                    StartDate = ev.StartDate,
                    EndDate = ev.EndDate,
                    IsActive = ev.IsActive,
                    IsPaid = ev.IsPaid,
                    IsPublished = ev.IsPublished,
                    Status = ev.Status,
                    Place = ev.Place,
                    Price = ev.Price,
                    Quota = ev.Quota,
                    Thumbnail = ev.Thumbnail,
                    UsedQuota = ev.UsedQuota,
                }).ToList();
            }
            else
            {
                return null;
            }
        }

        if (userRole == nameof(RoleLevel.Employee))
        {
            var employee = _employeeRepository.GetAll().FirstOrDefault(e => e.AccountGuid == Guid.Parse(accountGuid!));

            if (employee is not null)
            {
                var getInternalEvents = new List<Event>();

                if (string.Equals(type, nameof(EventTypeEnum.Public), StringComparison.OrdinalIgnoreCase))
                {
                    getInternalEvents = _eventRepository.GetEventsByCreatedBy(employee.CompanyGuid).Where(ev => ev.IsPublished is true && ev.IsActive is true).ToList();

                }
                else if (string.Equals(type, nameof(EventTypeEnum.Personal), StringComparison.OrdinalIgnoreCase))
                {
                    getInternalEvents = _eventRepository.GetEventsByCreatedBy(employee.CompanyGuid).Where(ev => ev.IsPublished is false && ev.IsActive is true).ToList();
                }
                else
                {
                    getInternalEvents = _eventRepository.GetEventsByCreatedBy(employee.CompanyGuid).Where(ev => ev.IsActive is true).ToList();
                }

                var internalEventsIsActive = getInternalEvents.Select(ev => new EventsDto
                {
                    Guid = ev.Guid,
                    Name = ev.Name,
                    Description = ev.Description,
                    Category = ev.Category,
                    CreatedBy = ev.CreatedBy,
                    StartDate = ev.StartDate,
                    EndDate = ev.EndDate,
                    IsActive = ev.IsActive,
                    IsPaid = ev.IsPaid,
                    IsPublished = ev.IsPublished,
                    Status = ev.Status,
                    Place = ev.Place,
                    Price = ev.Price,
                    Quota = ev.Quota,
                    Thumbnail = ev.Thumbnail,
                    UsedQuota = ev.UsedQuota,
                }).ToList();

                var employeeParticipants = _employeeParticipantRepository.GetAll();

                foreach (var internalEvent in internalEventsIsActive)
                {
                    if (employeeParticipants.FirstOrDefault(ep => ep.EmployeeGuid == employee.Guid && ep.EventGuid == internalEvent.Guid) is not null)
                    {
                        internalEvents.Add(internalEvent);
                    }
                }
            }
            else
            {
                return null;
            }

        }

        return internalEvents;
    }

    public List<EventsDto>? GetExternalEvents(string type = "")
    {
        var claimUser = _httpContextAccessor.HttpContext?.User;

        var userRole = claimUser?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        var accountGuid = claimUser?.Claims?.FirstOrDefault(x => x.Type == "Guid")?.Value;

        var externalEvents = new List<EventsDto>();

        if (userRole == nameof(RoleLevel.Company))
        {
            var company = _companyRepository.GetAll().FirstOrDefault(c => c.AccountGuid == Guid.Parse(accountGuid!));

            if (company != null)
            {
                var getExternalEvents = new List<Event>();

                if (string.Equals(type, nameof(EventTypeEnum.Public), StringComparison.OrdinalIgnoreCase))
                {
                    getExternalEvents = _eventRepository.GetAll().Where(ev => ev.CreatedBy != company.Guid && ev.IsPublished is true && ev.IsActive is true).ToList();

                }
                else if (string.Equals(type, nameof(EventTypeEnum.Personal), StringComparison.OrdinalIgnoreCase))
                {
                    getExternalEvents = _eventRepository.GetAll().Where(ev => ev.CreatedBy != company.Guid && ev.IsPublished is false && ev.IsActive is true).ToList();
                }
                else
                {
                    getExternalEvents = _eventRepository.GetAll().Where(ev => ev.CreatedBy != company.Guid && ev.IsActive is true).ToList();
                }

                var externalEventsIsActive = getExternalEvents.Select(ev => new EventsDto
                {
                    Guid = ev.Guid,
                    Name = ev.Name,
                    Description = ev.Description,
                    Category = ev.Category,
                    CreatedBy = ev.CreatedBy,
                    StartDate = ev.StartDate,
                    EndDate = ev.EndDate,
                    IsActive = ev.IsActive,
                    IsPaid = ev.IsPaid,
                    IsPublished = ev.IsPublished,
                    Status = ev.Status,
                    Place = ev.Place,
                    Price = ev.Price,
                    Quota = ev.Quota,
                    Thumbnail = ev.Thumbnail,
                    UsedQuota = ev.UsedQuota,
                }).ToList();

                var companyParticipants = _companyParticipantRepository.GetAll();

                foreach (var externalEvent in externalEventsIsActive)
                {
                    if (companyParticipants.FirstOrDefault(cp => cp.CompanyGuid == company.Guid && cp.EventGuid == externalEvent.Guid) is not null)
                    {
                        externalEvents.Add(externalEvent);
                    }
                }
            }
            else
            {
                return null;
            }
        }

        if (userRole == nameof(RoleLevel.Employee))
        {
            var employee = _employeeRepository.GetAll().FirstOrDefault(e => e.AccountGuid == Guid.Parse(accountGuid!));

            if (employee is not null)
            {
                var getExternalEvents = new List<Event>();

                if (string.Equals(type, nameof(EventTypeEnum.Public), StringComparison.OrdinalIgnoreCase))
                {
                    getExternalEvents = _eventRepository.GetAll().Where(ev => ev.CreatedBy != employee.CompanyGuid && ev.IsPublished is true && ev.IsActive is true).ToList();

                }
                else if (string.Equals(type, nameof(EventTypeEnum.Personal), StringComparison.OrdinalIgnoreCase))
                {
                    getExternalEvents = _eventRepository.GetAll().Where(ev => ev.CreatedBy != employee.CompanyGuid && ev.IsPublished is false && ev.IsActive is true).ToList();
                }
                else
                {
                    getExternalEvents = _eventRepository.GetAll().Where(ev => ev.CreatedBy != employee.CompanyGuid && ev.IsActive is true).ToList();
                }

                var externalEventsIsActive = getExternalEvents.Select(ev => new EventsDto
                {
                    Guid = ev.Guid,
                    Name = ev.Name,
                    Description = ev.Description,
                    Category = ev.Category,
                    CreatedBy = ev.CreatedBy,
                    StartDate = ev.StartDate,
                    EndDate = ev.EndDate,
                    IsActive = ev.IsActive,
                    IsPaid = ev.IsPaid,
                    IsPublished = ev.IsPublished,
                    Status = ev.Status,
                    Place = ev.Place,
                    Price = ev.Price,
                    Quota = ev.Quota,
                    Thumbnail = ev.Thumbnail,
                    UsedQuota = ev.UsedQuota,
                }).ToList();

                var employeeParticipants = _employeeParticipantRepository.GetAll();

                foreach (var externalEvent in externalEventsIsActive)
                {
                    if (employeeParticipants.FirstOrDefault(ep => ep.EmployeeGuid == employee.Guid && ep.EventGuid == externalEvent.Guid) is not null)
                    {
                        externalEvents.Add(externalEvent);
                    }
                }
            }
            else
            {
                return null;
            }

        }

        return externalEvents;
    }


    public GetMasterEventDto? GetDetailsEvent(Guid guid)
    {

        var getEvent = _eventRepository.GetByGuid(guid);

        if (getEvent is null)
        {
            return null;
        }

        var getMakerEvent = _companyRepository.GetByGuid(getEvent.CreatedBy);

        var companyParticipants = _companyParticipantRepository.GetAll().Where(cp => cp.EventGuid == guid).Select(cp => new CompanyParticipantsDto
        {
            Guid = cp.Guid,
            CompanyGuid = cp.CompanyGuid,
            EventGuid = cp.EventGuid,
            IsPresent = cp.IsPresent,
            Status = cp.Status
        }).ToList();

        var employeeParticipants = _employeeParticipantRepository.GetAll().Where(ep => ep.EventGuid == guid).Select(ep => new EmployeeParticipantsDto
        {
            Guid = ep.Guid,
            EmployeeGuid = ep.EmployeeGuid,
            EventGuid = ep.EventGuid,
            IsPresent = ep.IsPresent,
            Status = ep.Status
        }).ToList();

        var eventPayments = new List<GetEventPaymentDto>();

        if (getEvent.IsPaid && getEvent.Price > 0)
        {
            eventPayments = _eventPaymentRepository.GetAll().Where(evp => evp.EventGuid == guid).Select(evp => new GetEventPaymentDto
            {
                Guid = evp.Guid,
                EventGuid = evp.EventGuid,
                AccountGuid = evp.AccountGuid,
                BankGuid = evp.BankGuid,
                IsValid = evp.IsValid,
                PaymentImage = evp.PaymentImage,
                StatusPayment = evp.StatusPayment,
                VaNumber = evp.VaNumber,
            }).ToList();
        }

        var getMasterEventDto = new GetMasterEventDto
        {
            EventGuid = getEvent.Guid,
            Description = getEvent.Description,
            EventName = getEvent.Name,
            StartDate = getEvent.StartDate,
            EndDate = getEvent.EndDate,
            IsActive = getEvent.IsActive,
            IsPublished = getEvent.IsPublished,
            IsPaid = getEvent.IsPaid,
            Price = getEvent.Price,
            Place = getEvent.Place,
            Category = getEvent.Category,
            Quota = getEvent.Quota,
            UsedQuota = getEvent.UsedQuota,
            Status = getEvent.Status,
            Thumbnail = getEvent.Thumbnail,
            CreatedBy = getEvent.CreatedBy,
            CompanyName = getMakerEvent?.Name,
            CompanyParticipants = companyParticipants,
            EmployeeParticipants = employeeParticipants,
            EventPayments = eventPayments,
        };

        return getMasterEventDto;
    }

    public List<EventsDto>? GetPublicEvents()
    {
        var claimUser = _httpContextAccessor.HttpContext?.User;

        var userRole = claimUser?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        var accountGuid = claimUser?.Claims?.FirstOrDefault(x => x.Type == "Guid")?.Value;

        var publicEventsParticipant = new List<EventsDto>();
        var companies = _companyRepository.GetAll();

        var publicEvents = _eventRepository.GetAll().Where(ev => ev.IsPublished is true && ev.IsActive is true).Select(e =>
        {
            var makerEvent = companies.FirstOrDefault(c => c.Guid == e.CreatedBy);

            return new EventsDto
            {
                Guid = e.Guid,
                Name = e.Name,
                Description = e.Description,
                Thumbnail = e.Thumbnail,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                IsPublished = e.IsPublished,
                IsActive = e.IsActive,
                IsPaid = e.IsPaid,
                Price = e.Price,
                Status = e.Status,
                Place = e.Place,
                Quota = e.Quota,
                UsedQuota = e.UsedQuota,
                Category = e.Category,
                CreatedBy = e.CreatedBy,
                MakerName = makerEvent?.Name
            };
        });

        if (userRole == nameof(RoleLevel.Company))
        {
            var company = _companyRepository.GetAll().FirstOrDefault(c => c.AccountGuid == Guid.Parse(accountGuid!));

            if (company is null)
            {
                return null;
            }

            var companyParticipants = _companyParticipantRepository.GetAll();

            foreach (var publicEvent in publicEvents)
            {
                if (companyParticipants.FirstOrDefault(cp => cp.CompanyGuid == company.Guid && cp.EventGuid == publicEvent.Guid) is not null || publicEvent.CreatedBy == company.Guid)
                {
                    publicEventsParticipant.Add(publicEvent);
                }
            }
        }


        if (userRole == nameof(RoleLevel.Employee))
        {
            var employee = _employeeRepository.GetAll().FirstOrDefault(e => e.AccountGuid == Guid.Parse(accountGuid!));

            if (employee is null)
            {
                return null;
            }

            var employeeParticipants = _employeeParticipantRepository.GetAll();

            foreach (var publicEvent in publicEvents)
            {
                if (employeeParticipants.FirstOrDefault(ep => ep.EmployeeGuid == employee.Guid && ep.EventGuid == publicEvent.Guid) is not null)
                {
                    publicEventsParticipant.Add(publicEvent);
                }
            }
        }

        return publicEventsParticipant;
    }

    public List<EventsDto>? GetPersonalEvents()
    {
        var claimUser = _httpContextAccessor.HttpContext?.User;

        var userRole = claimUser?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        var accountGuid = claimUser?.Claims?.FirstOrDefault(x => x.Type == "Guid")?.Value;

        var publicEventsParticipant = new List<EventsDto>();
        var companies = _companyRepository.GetAll();

        var publicEvents = _eventRepository.GetAll().Where(ev => ev.IsPublished is false && ev.IsActive is true).Select(e =>
        {
            var makerEvent = companies.FirstOrDefault(c => c.Guid == e.CreatedBy);

            return new EventsDto
            {
                Guid = e.Guid,
                Name = e.Name,
                Description = e.Description,
                Thumbnail = e.Thumbnail,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                IsPublished = e.IsPublished,
                IsActive = e.IsActive,
                IsPaid = e.IsPaid,
                Price = e.Price,
                Status = e.Status,
                Place = e.Place,
                Quota = e.Quota,
                UsedQuota = e.UsedQuota,
                Category = e.Category,
                CreatedBy = e.CreatedBy,
                MakerName = makerEvent?.Name
            };
        });

        if (userRole == nameof(RoleLevel.Company))
        {
            var company = _companyRepository.GetAll().FirstOrDefault(c => c.AccountGuid == Guid.Parse(accountGuid!));

            if (company is null)
            {
                return null;
            }

            var companyParticipants = _companyParticipantRepository.GetAll();

            foreach (var publicEvent in publicEvents)
            {
                if (companyParticipants.FirstOrDefault(cp => cp.CompanyGuid == company.Guid && cp.EventGuid == publicEvent.Guid) is not null || publicEvent.CreatedBy == company.Guid)
                {
                    publicEventsParticipant.Add(publicEvent);
                }
            }
        }


        if (userRole == nameof(RoleLevel.Employee))
        {
            var employee = _employeeRepository.GetAll().FirstOrDefault(e => e.AccountGuid == Guid.Parse(accountGuid!));

            if (employee is null)
            {
                return null;
            }

            var employeeParticipants = _employeeParticipantRepository.GetAll();

            foreach (var publicEvent in publicEvents)
            {
                if (employeeParticipants.FirstOrDefault(ep => ep.EmployeeGuid == employee.Guid && ep.EventGuid == publicEvent.Guid) is not null)
                {
                    publicEventsParticipant.Add(publicEvent);
                }
            }
        }

        return publicEventsParticipant;
    }


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


        if (userRole == nameof(RoleLevel.Employee))
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

        return userTickets;
    }
}



