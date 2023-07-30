using API.Contracts;
using API.DTOs.CompanyParticipants;
using API.DTOs.EmployeeParticipants;
using API.DTOs.EventPayments;
using API.DTOs.Events;
using API.Models;
using API.Utilities.Enums;
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

    public IEnumerable<EventsDto>? GetEvents()
    {
        var eventsModel = _eventRepository.GetAll();

        if (eventsModel is null)
        {
            return null;
        }

        var events = eventsModel.Select(e => new EventsDto
        {
            Guid = e.Guid,
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
        }).ToList();

        return events;
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
}



