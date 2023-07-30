using API.Contracts;
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


    public List<EventsDto>? GetInternalEvents()
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
                internalEvents = _eventRepository.GetEventsByCreatedBy(company.Guid).Select(ev => new EventsDto
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
                    MakerName = company.Name,
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
                var company = _companyRepository.GetByGuid(employee.CompanyGuid);

                var internalEventsIsActive = _eventRepository.GetEventsByCreatedBy(employee.CompanyGuid).Where(ev => ev.IsActive is true).Select(ev => new EventsDto
                {
                    Guid = ev.Guid,
                    Name = ev.Name,
                    Description = ev.Description,
                    Category = ev.Category,
                    CreatedBy = ev.CreatedBy,
                    MakerName = company.Name,
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
}



