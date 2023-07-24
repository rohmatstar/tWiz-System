using API.Contracts;
using API.DTOs.EventPayments;
using API.Models;
using API.Repositories;

namespace API.Services;

public class EventPaymentService
{
    private readonly IEventPaymentRepository _eventPaymentRepository;

    public EventPaymentService(IEventPaymentRepository eventPaymentRepository)
    {
        _eventPaymentRepository = eventPaymentRepository;
    }

    public IEnumerable<GetEventPaymentDto> GetEventPayments()
    {
        var eventPayments = _eventPaymentRepository.GetAll();
        if (!eventPayments.Any())
        {
            return null; // No EventPayment Found
        }
        var toDto = eventPayments.Select(eventPayments => new GetEventPaymentDto
        {
            Guid = eventPayments.Guid,
            AccountGuid = eventPayments.AccountGuid,
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
        var toDto = new GetEventPaymentDto
        {
            Guid = eventPayments.Guid,
            AccountGuid = eventPayments.AccountGuid,
            VaNumber = eventPayments.VaNumber,
            PaymentImage = eventPayments.PaymentImage,
            IsValid = eventPayments.IsValid,
            BankGuid = eventPayments.BankGuid,
        };
        return toDto;

    }

    public GetEventPaymentDto? CreateEventPayment(CreateEventPaymentDto newEventPaymentDto)
    {
        var eventPayment = new EventPayment
        {
            Guid = new Guid(),
            AccountGuid = newEventPaymentDto.AccountGuid,
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


    public int DeleteEmployee(Guid guid)
    {
        var isExist = _eventPaymentRepository.IsExist(guid);
        if (!isExist)
        {
            return -1; // EventPayment Not Found
        }

        var employee = _eventPaymentRepository.GetByGuid(guid);
        var isDelete = _eventPaymentRepository.Delete(employee);
        if (!isDelete)
        {
            return 0; // EventPayment Not Deleted
        }

        return 1; // EventPayment Deleted
    }
}
