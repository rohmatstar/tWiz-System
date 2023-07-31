using API.Contracts;
using API.DTOs.EmployeeParticipants;
using API.Models;
using System.Security.Claims;

namespace API.Services;

public class EmployeeParticipantService
{
    private readonly IEmployeeParticipantRepository _employeeParticipantRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IEventRepository _eventRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IEventPaymentRepository _eventPaymentRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public EmployeeParticipantService(IEmployeeParticipantRepository employeeParticipant, IHttpContextAccessor httpContextAccessor, IEventRepository eventRepository, IEmployeeRepository employeeRepository, IEventPaymentRepository eventPaymentRepository, ICompanyRepository companyRepository)
    {
        _employeeParticipantRepository = employeeParticipant;
        _httpContextAccessor = httpContextAccessor;
        _eventRepository = eventRepository;
        _employeeRepository = employeeRepository;
        _eventPaymentRepository = eventPaymentRepository;
        _companyRepository = companyRepository;
    }

    public IEnumerable<EmployeeParticipantsDto>? GetEmployeeParticipants()
    {
        var model = _employeeParticipantRepository.GetAll();

        if (model is null)
        {
            return null;
        }

        var data = model.Select(e => new EmployeeParticipantsDto
        {
            Guid = e.Guid,
            EventGuid = e.EventGuid,
            EmployeeGuid = e.EmployeeGuid,
            Status = e.Status,
            IsPresent = e.IsPresent
        }).ToList();

        return data;
    }

    public EmployeeParticipantsDto? GetEmployeeParticipant(Guid guid)
    {
        var model = _employeeParticipantRepository.GetByGuid(guid);

        if (model is null)
        {
            return null;
        }

        var e = model;

        var data = new EmployeeParticipantsDto
        {
            Guid = e.Guid,
            EventGuid = e.EventGuid,
            EmployeeGuid = e.EmployeeGuid,
            Status = e.Status,
            IsPresent = e.IsPresent
        };

        return data;
    }

    public EmployeeParticipantsDto? CreateEmployeeParticipant(CreateEmployeeParticipantDto create)
    {
        var model = new EmployeeParticipant
        {
            Guid = new Guid(),
            EventGuid = create.EventGuid,
            EmployeeGuid = create.EmployeeGuid,
            Status = create.Status,
            IsPresent = create.IsPresent,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };

        var created = _employeeParticipantRepository.Create(model);
        if (created is null)
        {
            return null;
        }


        var data = new EmployeeParticipantsDto
        {
            Guid = model.Guid,
            EventGuid = model.EventGuid,
            EmployeeGuid = model.EmployeeGuid,
            Status = model.Status,
            IsPresent = model.IsPresent
        };

        return data;
    }

    public EmployeeParticipantsDto? UpdateEmployeeParticipant(EmployeeParticipantsDto update)
    {
        var single = _employeeParticipantRepository.GetByGuid(update.Guid);
        if (single == null)
        {
            return null;
        }

        var model = new EmployeeParticipant
        {
            Guid = update!.Guid,
            EventGuid = update!.EventGuid,
            EmployeeGuid = update!.EmployeeGuid,
            Status = update!.Status,
            IsPresent = update!.IsPresent
        };

        var isUpdate = _employeeParticipantRepository.Update(model);
        if (!isUpdate)
        {
            return null;
        }

        var data = new EmployeeParticipantsDto
        {
            Guid = model!.Guid,
            EventGuid = model!.EventGuid,
            EmployeeGuid = model!.EmployeeGuid,
            Status = model!.Status,
            IsPresent = model!.IsPresent
        };

        return data;
    }

    public EmployeeParticipantsDto? DeleteEmployeeParticipant(Guid guid)
    {
        var model = _employeeParticipantRepository.GetByGuid(guid);
        if (model == null)
        {
            return null;
        }

        var isDelete = _employeeParticipantRepository.Delete(model!);
        if (!isDelete)
        {
            return null;
        }

        var deleted = new EmployeeParticipantsDto
        {
            Guid = model!.Guid,
            EventGuid = model!.EventGuid,
            EmployeeGuid = model!.EmployeeGuid,
            Status = model!.Status,
            IsPresent = model!.IsPresent
        };

        return deleted;
    }

    public int UpdateEmployeeParticipants(UpdateEmployeParticipantsDto updateEmployeeParticipantsDto)
    {
        var claimUser = _httpContextAccessor.HttpContext?.User;

        var userRole = claimUser?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        var accountGuid = claimUser?.Claims?.FirstOrDefault(x => x.Type == "Guid")?.Value;

        var company = _companyRepository.GetAll().FirstOrDefault(c => c.AccountGuid == Guid.Parse(accountGuid!));

        if (company is null)
        {
            return 0;
        }

        var employeesCompany = (from ep in _employeeParticipantRepository.GetAll()
                                join e in _employeeRepository.GetAll()
                                on ep.EmployeeGuid equals e.Guid
                                where ep.EventGuid == updateEmployeeParticipantsDto.EventGuid && e.CompanyGuid == company.Guid
                                select ep).ToList();

        if (employeesCompany is not null || employeesCompany.Count > 0)
        {
            return -1;
        }


        return 1;
    }
}

