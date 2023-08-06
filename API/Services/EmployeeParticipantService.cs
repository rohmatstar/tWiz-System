using API.Contracts;
using API.Data;
using API.DTOs.EmployeeParticipants;
using API.Models;
using API.Utilities.Enums;
using API.Utilities.Handlers;
using System.Security.Claims;

namespace API.Services;

public class EmployeeParticipantService
{
    private readonly IEmployeeParticipantRepository _employeeParticipantRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IEventRepository _eventRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IEventPaymentRepository _eventPaymentRepository;
    private readonly IBankRepository _bankRepository;
    private readonly TwizDbContext _twizDbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public EmployeeParticipantService(IEmployeeParticipantRepository employeeParticipant, IHttpContextAccessor httpContextAccessor, IEventRepository eventRepository, IEmployeeRepository employeeRepository, IEventPaymentRepository eventPaymentRepository, ICompanyRepository companyRepository, TwizDbContext twizDbContext, IBankRepository bankRepository)
    {
        _employeeParticipantRepository = employeeParticipant;
        _httpContextAccessor = httpContextAccessor;
        _eventRepository = eventRepository;
        _employeeRepository = employeeRepository;
        _eventPaymentRepository = eventPaymentRepository;
        _companyRepository = companyRepository;
        _twizDbContext = twizDbContext;
        _bankRepository = bankRepository;
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


    public List<GetEmployeeParticipantDto>? GetEmployeeParticipantsByEvent(Guid eventGuid)
    {
        var getEvent = _eventRepository.GetByGuid(eventGuid);

        if (getEvent == null)
        {
            return null;
        }
        var employees = _employeeRepository.GetAll();
        var companies = _companyRepository.GetAll();

        var employeeParticipants = _employeeParticipantRepository.GetAll().Where(ep => ep.EventGuid == eventGuid).Select(ep =>
        {
            var employee = employees.FirstOrDefault(e => e.Guid == ep.EmployeeGuid);
            var company = companies.FirstOrDefault(e => e.Guid == employee.CompanyGuid);

            var invitationStatus = "";

            if (ep.Status == InviteStatusLevel.Pending) invitationStatus = "pending";
            if (ep.Status == InviteStatusLevel.Checking) invitationStatus = "checking";
            if (ep.Status == InviteStatusLevel.Accepted) invitationStatus = "accepted";
            if (ep.Status == InviteStatusLevel.Rejected) invitationStatus = "rejected";


            return new GetEmployeeParticipantDto
            {
                Guid = ep.Guid,
                EventName = getEvent.Name,
                EmployeeGuid = ep.EmployeeGuid,
                EmployeeName = employee.FullName,
                CompanyName = company.Name,
                InvitationStatus = invitationStatus ?? "",
                IsPresent = ep.IsPresent
            };
        }).ToList();

        if (employeeParticipants is null)
        {
            return null;
        }

        var claimUser = _httpContextAccessor.HttpContext?.User;

        var userRole = claimUser?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        var accountGuid = claimUser?.Claims?.FirstOrDefault(x => x.Type == "Guid")?.Value;



        if (userRole == nameof(RoleLevel.Company))
        {
            var company = _companyRepository.GetAll().FirstOrDefault(c => c.AccountGuid == Guid.Parse(accountGuid!));

            if (company is null)
            {
                return null;
            }

            employeeParticipants = employeeParticipants.Where(ep => ep.CompanyName == company.Name).ToList();
        }



        return employeeParticipants;
    }

    public int UpdateCompanyEmployeeParticipantsEvent(UpdateEmployeParticipantsDto updateEmployeParticipantsDto)
    {
        var claimUser = _httpContextAccessor.HttpContext?.User;

        var userRole = claimUser?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        var accountGuid = claimUser?.Claims?.FirstOrDefault(x => x.Type == "Guid")?.Value;

        var company = _companyRepository.GetAll().FirstOrDefault(c => c.AccountGuid == Guid.Parse(accountGuid!));

        var getEvent = _eventRepository.GetByGuid(updateEmployeParticipantsDto.EventGuid);

        if (company is null)
        {
            return 0;
        }

        var employees = _employeeRepository.GetAll();
        var previousEmployeeCompanyParticipantsEvent = _employeeParticipantRepository.GetAll().Where(ep =>
        {
            var employee = employees.FirstOrDefault(e => e.Guid == ep.EmployeeGuid);

            bool isCompanyEmployee = employee.CompanyGuid == company.Guid;

            return ep.EventGuid == getEvent.Guid && isCompanyEmployee;
        }).ToList();

        var previousEventPayments = new List<EventPayment>();

        if (getEvent.IsPaid)
        {
            previousEventPayments = _eventPaymentRepository.GetAll().Where(ep =>
            {
                var employee = employees.FirstOrDefault(e => e.AccountGuid == ep.AccountGuid);

                if (employee is null)
                {
                    // bukan employee
                    return false;
                }

                var isCompanyEmployee = employee.CompanyGuid == company.Guid;

                return ep.EventGuid == getEvent.Guid && isCompanyEmployee;
            }).ToList();
        }

        var transaction = _twizDbContext.Database.BeginTransaction();

        var deletedEmployeeParticipants = _employeeParticipantRepository.Deletes(previousEmployeeCompanyParticipantsEvent);

        if (deletedEmployeeParticipants is false)
        {
            transaction.Rollback();
            return 0;
        }

        if (getEvent.IsPaid)
        {
            var deletedPreviousEventPaymets = _eventPaymentRepository.Deletes(previousEventPayments);

            if (deletedPreviousEventPaymets == false)
            {
                transaction.Rollback();
                return 0;
            }
        }

        var newEmployeeParticipants = new List<EmployeeParticipant>();
        var newEventPaymentsEvent = new List<EventPayment>();

        foreach (var newEmployeeParticipantGuid in updateEmployeParticipantsDto.EmployeesGuids)
        {
            var newEmployeeParticipant = new EmployeeParticipant
            {
                Guid = new Guid(),
                EventGuid = getEvent.Guid,
                EmployeeGuid = newEmployeeParticipantGuid,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,

            };

            if (getEvent.IsPaid)
            {
                var employee = _employeeRepository.GetByGuid(newEmployeeParticipantGuid);

                var getBanks = _bankRepository.GetAll().ToList();
                if (getBanks is null || getBanks.Count == 0)
                {
                    transaction.Rollback();
                    return 0; // Atau tindakan lain jika daftar kosong.
                }

                Random random = new Random();
                int randomIndex = random.Next(0, getBanks.Count - 1); // Mendapatkan indeks acak dalam rentang [0, count-1].
                var randomBank = getBanks[randomIndex]; // Mendapatkan bank secara acak.

                var eventPayment = new EventPayment
                {
                    Guid = new Guid(),
                    EventGuid = getEvent.Guid,
                    AccountGuid = employee.AccountGuid,
                    BankGuid = randomBank.Guid,
                    IsValid = false,
                    PaymentImage = "",
                    StatusPayment = StatusPayment.Pending,
                    VaNumber = GenerateHandler.GenerateVa(),
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };


                newEventPaymentsEvent.Add(eventPayment);
            }

            newEmployeeParticipants.Add(newEmployeeParticipant);
        }

        var createdEmployeeParticipants = _employeeParticipantRepository.Creates(newEmployeeParticipants);

        if (createdEmployeeParticipants is false)
        {
            transaction.Rollback();
            return 0;
        }

        if (getEvent.IsPaid)
        {
            var createdEventPayments = _eventPaymentRepository.Creates(newEventPaymentsEvent);

            if (createdEventPayments == false)
            {
                transaction.Rollback();
                return 0;
            }
        }

        transaction.Commit();

        return 1;
    }
}

