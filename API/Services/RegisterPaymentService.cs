using API.Contracts;
using API.DTOs.RegisterPayments;
using API.Models;
using API.Utilities.Enums;
using API.Utilities.Handlers;
using API.Utilities.Validations;

namespace API.Services;

public class RegisterPaymentService
{
    private readonly IRegisterPaymentRepository _registerPaymentRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IEmailHandler _emailHandler;
    public RegisterPaymentService(IRegisterPaymentRepository registerPaymentRepository, ICompanyRepository companyRepository, IAccountRepository accountRepository, IEmailHandler emailHandler)
    {
        _registerPaymentRepository = registerPaymentRepository;
        _companyRepository = companyRepository;
        _accountRepository = accountRepository;
        _emailHandler = emailHandler;
    }

    public IEnumerable<GetRegisterPaymentDto>? GetRegisterPayments()
    {
        var registerPayments = _registerPaymentRepository.GetAll();
        if (registerPayments is null)
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
            StatusPayment = registerPayments.StatusPayment
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
            PaymentImage = UpdateRegisterPaymentDto.PaymentImage ?? "",
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
        var isDelete = _registerPaymentRepository.Delete(registerpayment!);
        if (!isDelete)
        {
            return 0; // RegisterPayment Not Deleted
        }

        return 1; // RegisterPayment Deleted
    }

    public async Task<int> UploadPaymentSubmission(PaymentSubmissionDto paymentSubmissionDto)
    {
        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\register_payments");



        if (!Directory.Exists(folderPath))
        {
            try
            {
                Directory.CreateDirectory(folderPath);
                Console.WriteLine("Folder created successfully!");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Failed to create folder: " + ex.Message);
                return -1;
            }
        }
        else
        {
            Console.WriteLine("Folder already exists.");
        }

        var size = paymentSubmissionDto.PaymentImage.Length;

        // jika ukuran gambar lebih dari 2mb
        if (size > 2000000)
        {
            return -2;
        }

        bool isImage = FileValidation.IsValidImageExtension(paymentSubmissionDto.PaymentImage);

        if (!isImage)
        {
            return -3;
        }


        var paymentRegisterByGuid = _registerPaymentRepository.GetByGuid(paymentSubmissionDto.Guid);
        var oldImageUrl = "";

        if (paymentRegisterByGuid != null)
        {
            oldImageUrl = paymentRegisterByGuid.PaymentImage;
        }
        else
        {
            return -4;
        }


        var randomName = GenerateHandler.GenerateRandomString();
        var fileName = randomName + paymentSubmissionDto.PaymentImage.FileName;
        var urlImage = $"images/register_payments/{fileName}";

        var filePath = $"{folderPath}\\{fileName}";

        try
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await paymentSubmissionDto.PaymentImage.CopyToAsync(stream);
            }

            paymentSubmissionDto.PaymentImageUrl = urlImage;

            // update payment image
            bool paymentImageUpdated = _registerPaymentRepository.UpdatePaymentImage(paymentSubmissionDto);
            if (!paymentImageUpdated)
            {
                File.Delete(filePath);
                return -4;
            }

            // update status payment
            bool statusPaymentUpdated = _registerPaymentRepository.ChangeStatusRegisterPayment(paymentSubmissionDto.Guid, StatusPayment.Checking);

            if (!statusPaymentUpdated)
            {
                File.Delete(filePath);
                return -5;
            }

            // hapus foto lama
            File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", oldImageUrl.Replace("/", "\\")));
        }
        catch
        {
            File.Delete(filePath);
            return -4;
        }

        return 1;
    }

    //Testing Mail Service
    /* public PaymentDto Payment(string email)
     {
         var company = _accountRepository.GetAll().SingleOrDefault(account => account.Email == email);
         if (company is null)
         {
             return null;
         }

         var toDto = new PaymentDto
         {
             Email = company.Email,
             VaNumber = GenerateVA.GenerateRandomVA(),
         };

         var relatedAccount = _accountRepository.GetByGuid(company.Guid);

         var update = new RegisterPayment
         {
             Guid = relatedAccount.Guid,
             VaNumber = toDto.VaNumber,


         };

         var updateResult = _registerPaymentRepository.Update(update);

         _emailHandler.SendEmail(toDto.Email,
                        "Register Payment",
                        $"Your Virtual Account Number is {toDto.VaNumber}");

         return toDto;
     }*/
}
