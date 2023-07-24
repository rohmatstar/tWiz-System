using API.Contracts;
using API.DTOs.RegisterPayments;
using API.Models;
using API.Repositories;

namespace API.Services;

public class RegisterPaymentService
{
    private readonly IRegisterPaymentRepository _registerPaymentRepository;
    
    public RegisterPaymentService(IRegisterPaymentRepository registerPaymentRepository)
    {
        _registerPaymentRepository = registerPaymentRepository;
    }

    public IEnumerable<GetRegisterPaymentDto> GetRegisterPayments()
    {
        var registerPayments = _registerPaymentRepository.GetAll();
        if (!registerPayments.Any())
        {
            return null; // No RegisterPayment Found
        }
        var toDto = registerPayments.Select(registerPayments => new GetRegisterPaymentDto
        {
            Guid = registerPayments.Guid,
            CompanyGuid = registerPayments.CompanyGuid,
            VaNumber = registerPayments.VaNumber,
            Price = registerPayments.Price,
            PaymentImage = registerPayments.PaymentImage,
            IsValid = registerPayments.IsValid,
            BankGuid = registerPayments.BankGuid,

        }).ToList();

        return toDto;
    }

    public GetRegisterPaymentDto? GetRegisterPayment(Guid guid)
    {
        var registerPayments = _registerPaymentRepository.GetByGuid(guid);
        if (registerPayments is null)
        {
            return null;
        }
        var toDto = new GetRegisterPaymentDto
        {
            Guid = registerPayments.Guid,
            CompanyGuid = registerPayments.CompanyGuid,
            VaNumber = registerPayments.VaNumber,
            Price = registerPayments.Price,
            PaymentImage = registerPayments.PaymentImage,
            IsValid = registerPayments.IsValid,
            BankGuid = registerPayments.BankGuid,
        };
        return toDto;

    }

    public GetRegisterPaymentDto? CreateEventPayment(CreateRegisterPaymentDto newRegisterPaymentDto)
    {
        var registerPayment = new RegisterPayment
        {
            Guid = new Guid(),
            CompanyGuid = newRegisterPaymentDto.CompanyGuid,
            VaNumber = newRegisterPaymentDto.VaNumber,
            Price = newRegisterPaymentDto.Price,
            PaymentImage = newRegisterPaymentDto.PaymentImage,
            IsValid = newRegisterPaymentDto.IsValid,
            BankGuid = newRegisterPaymentDto.BankGuid,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };

        var createdRegisterPayment = _registerPaymentRepository.Create(registerPayment);
        if (createdRegisterPayment is null)
        {
            return null; // RegisterPayment Not Created
        }

        var toDto = new GetRegisterPaymentDto
        {
            Guid = createdRegisterPayment.Guid,
            CompanyGuid = createdRegisterPayment.CompanyGuid,
            VaNumber = createdRegisterPayment.VaNumber,
            Price = createdRegisterPayment.Price,
            PaymentImage = createdRegisterPayment.PaymentImage,
            IsValid = createdRegisterPayment.IsValid,
            BankGuid = createdRegisterPayment.BankGuid,
        };

        return toDto; // RegisterPayment Created
    }

    public int UpdateRegisterPayment(UpdateRegisterPaymentDto UpdateRegisterPaymentDto)
    {
        var isExist = _registerPaymentRepository.IsExist(UpdateRegisterPaymentDto.Guid);
        if (!isExist)
        {
            return -1; // RegisterPayment Not Found
        }

        var getRegisterPayment = _registerPaymentRepository.GetByGuid(UpdateRegisterPaymentDto.Guid);

        var registerpayment = new RegisterPayment
        {
            Guid = UpdateRegisterPaymentDto.Guid,
            CompanyGuid = UpdateRegisterPaymentDto.CompanyGuid,
            VaNumber = UpdateRegisterPaymentDto.VaNumber,
            Price = UpdateRegisterPaymentDto.Price,
            PaymentImage = UpdateRegisterPaymentDto.PaymentImage,
            IsValid = UpdateRegisterPaymentDto.IsValid,
            BankGuid = UpdateRegisterPaymentDto.BankGuid,
            ModifiedDate = DateTime.Now,
            CreatedDate = getRegisterPayment!.CreatedDate
        };

        var isUpdate = _registerPaymentRepository.Update(registerpayment);
        if (!isUpdate)
        {
            return 0; // RegisterPayment Not Updated
        }
        return 1;
    }


    public int DeleteRegisterPayment(Guid guid)
    {
        var isExist = _registerPaymentRepository.IsExist(guid);
        if (!isExist)
        {
            return -1; // RegisterPayment Not Found
        }

        var registerpayment = _registerPaymentRepository.GetByGuid(guid);
        var isDelete = _registerPaymentRepository.Delete(registerpayment);
        if (!isDelete)
        {
            return 0; // RegisterPayment Not Deleted
        }

        return 1; // RegisterPayment Deleted
    }
}
