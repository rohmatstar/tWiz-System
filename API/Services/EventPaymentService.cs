using API.Contracts;
using API.DTOs.EventPayments;
using API.Models;
using API.Utilities.Enums;
using System.Security.Claims;

namespace API.Services;

public class EventPaymentService
{
    private readonly IEventPaymentRepository _eventPaymentRepository;
    private readonly IBankRepository _bankRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IEventRepository _eventRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public EventPaymentService(IEventPaymentRepository eventPaymentRepository, IBankRepository bankRepository, ICompanyRepository companyRepository, IEmployeeRepository employeeRepository, IEventRepository eventRepository, IHttpContextAccessor httpContextAccessor)
    {
        _eventPaymentRepository = eventPaymentRepository;
        _bankRepository = bankRepository;
        _companyRepository = companyRepository;
        _employeeRepository = employeeRepository;
        _eventRepository = eventRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public IEnumerable<GetEventPaymentDto>? GetEventPayments()
    {
        var eventPayments = _eventPaymentRepository.GetAll();
        if (eventPayments is null)
        {
            return null; // No EventPayment Found
        }
        var toDto = eventPayments.Select(eventPayments => new GetEventPaymentDto
        {
            Guid = eventPayments.Guid,
            AccountGuid = eventPayments.AccountGuid,
            EventGuid = eventPayments.EventGuid,
            VaNumber = eventPayments.VaNumber,
            PaymentImage = eventPayments.PaymentImage,
            IsValid = eventPayments.IsValid,
            BankGuid = eventPayments.BankGuid,

        }).ToList();

        return toDto;
    }

    public GetEventPaymentDto? GetEventPayment(Guid guid)
    {
        var eventPayments = _eventPaymentRepository.GetByGuid(guid);
        if (eventPayments is null)
        {
            return null;
        }

        var eventName = _eventRepository.GetByGuid(eventPayments.EventGuid)?.Name;
        var bankName = _bankRepository.GetByGuid(eventPayments.BankGuid)?.Name;

        var statusPayment = "";

        if (eventPayments.StatusPayment == StatusPayment.Pending) statusPayment = "pending";
        if (eventPayments.StatusPayment == StatusPayment.Checking) statusPayment = "checking";
        if (eventPayments.StatusPayment == StatusPayment.Paid) statusPayment = "paid";
        if (eventPayments.StatusPayment == StatusPayment.Rejected) statusPayment = "rejected";


        var getEventPayment = new GetEventPaymentDto
        {
            Guid = eventPayments.Guid,
            AccountGuid = eventPayments.AccountGuid,
            EventGuid = eventPayments.EventGuid,
            VaNumber = eventPayments.VaNumber,
            PaymentImage = eventPayments.PaymentImage,
            IsValid = eventPayments.IsValid,
            BankGuid = eventPayments.BankGuid,
            BankName = bankName ?? "",
            EventName = eventName ?? "",
            StatusPayment = statusPayment ?? ""
        };

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

            getEventPayment.AccountName = company.Name;
        }
        else if (userRole == nameof(RoleLevel.Employee))
        {
            var employee = _employeeRepository.GetAll().FirstOrDefault(c => c.AccountGuid == Guid.Parse(accountGuid!));

            if (employee is null)
            {
                return null;
            }

            getEventPayment.AccountName = employee.FullName;
        }
        else
        {
            return null;
        }

        return getEventPayment;

    }

    public GetEventPaymentDto? CreateEventPayment(CreateEventPaymentDto newEventPaymentDto)
    {
        var eventPayment = new EventPayment
        {
            Guid = new Guid(),
            AccountGuid = newEventPaymentDto.AccountGuid,
            EventGuid = newEventPaymentDto.EventGuid,
            VaNumber = newEventPaymentDto.VaNumber,
            PaymentImage = newEventPaymentDto.PaymentImage,
            IsValid = newEventPaymentDto.IsValid,
            BankGuid = newEventPaymentDto.BankGuid,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };

        var createdEventPayment = _eventPaymentRepository.Create(eventPayment);
        if (createdEventPayment is null)
        {
            return null; // EventPayment Not Created
        }

        var toDto = new GetEventPaymentDto
        {
            Guid = createdEventPayment.Guid,
            AccountGuid = createdEventPayment.AccountGuid,
            EventGuid = createdEventPayment.EventGuid,
            VaNumber = createdEventPayment.VaNumber,
            PaymentImage = createdEventPayment.PaymentImage,
            IsValid = createdEventPayment.IsValid,
            BankGuid = createdEventPayment.BankGuid,
        };

        return toDto; // EventPayment Created
    }

    public int UpdateEventPayment(UpdateEventPaymentDto UpdateEventPaymentDto)
    {
        var isExist = _eventPaymentRepository.IsExist(UpdateEventPaymentDto.Guid);
        if (!isExist)
        {
            return -1; // EventPayment Not Found
        }

        var getEventPayment = _eventPaymentRepository.GetByGuid(UpdateEventPaymentDto.Guid);

        var eventpayment = new EventPayment
        {
            Guid = UpdateEventPaymentDto.Guid,
            AccountGuid = UpdateEventPaymentDto.AccountGuid,
            EventGuid = UpdateEventPaymentDto.EventGuid,
            VaNumber = UpdateEventPaymentDto.VaNumber,
            PaymentImage = UpdateEventPaymentDto.PaymentImage,
            IsValid = UpdateEventPaymentDto.IsValid,
            BankGuid = UpdateEventPaymentDto.BankGuid,
            ModifiedDate = DateTime.Now,
            CreatedDate = getEventPayment!.CreatedDate
        };

        var isUpdate = _eventPaymentRepository.Update(eventpayment);
        if (!isUpdate)
        {
            return 0; // EventPayment Not Updated
        }
        return 1;
    }


    public int DeleteEventPayment(Guid guid)
    {
        var isExist = _eventPaymentRepository.IsExist(guid);
        if (!isExist)
        {
            return -1; // EventPayment Not Found
        }

        var eventpayment = _eventPaymentRepository.GetByGuid(guid);
        var isDelete = _eventPaymentRepository.Delete(eventpayment);
        if (!isDelete)
        {
            return 0; // EventPayment Not Deleted
        }

        return 1; // EventPayment Deleted
    }
}
