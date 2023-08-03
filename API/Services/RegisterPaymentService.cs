using API.Contracts;
using API.Data;
using API.DTOs.RegisterPayments;
using API.Models;
using API.Utilities.Enums;
using API.Utilities.Handlers;
using API.Utilities.Validations;
using System.Security.Claims;

namespace API.Services;

public class RegisterPaymentService
{
    private readonly IRegisterPaymentRepository _registerPaymentRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IEmailHandler _emailHandler;
    private readonly AccountService _accountService;
    private readonly TwizDbContext _twizDbContext;

    private readonly IHttpContextAccessor _httpContextAccessor;
    public RegisterPaymentService(IRegisterPaymentRepository registerPaymentRepository, ICompanyRepository companyRepository, IAccountRepository accountRepository, IEmailHandler emailHandler, AccountService accountService, TwizDbContext twizDbContext, IHttpContextAccessor httpContextAccessor)
    {
        _registerPaymentRepository = registerPaymentRepository;
        _companyRepository = companyRepository;
        _accountRepository = accountRepository;
        _emailHandler = emailHandler;
        _accountService = accountService;
        _twizDbContext = twizDbContext;
        _httpContextAccessor = httpContextAccessor;
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
            StatusPayment = registerPayments.StatusPayment
        };
        return toDto;

    }

    public GetRegisterPaymentDto? CreateRegisterPayment(CreateRegisterPaymentDto newRegisterPaymentDto)
    {
        var registerPayment = new RegisterPayment
        {
            Guid = new Guid(),
            CompanyGuid = newRegisterPaymentDto.CompanyGuid,
            VaNumber = newRegisterPaymentDto.VaNumber,
            Price = newRegisterPaymentDto.Price,
            PaymentImage = newRegisterPaymentDto.PaymentImage ?? "",
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
        var claimUser = _httpContextAccessor.HttpContext?.User;

        var userRole = claimUser?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        var accountGuid = claimUser?.Claims?.FirstOrDefault(x => x.Type == "Guid")?.Value;

        if (accountGuid is null)
        {
            return 0;
        }

        var companyName = "";

        if (userRole == nameof(RoleLevel.Company))
        {
            var company = _companyRepository.GetAll().FirstOrDefault(c => c.AccountGuid == Guid.Parse(accountGuid));

            companyName = company?.Name ?? "";
        }
        else
        {
            return 0;
        }

        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\register_payments");

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

        var registerPaymentByGuid = _registerPaymentRepository.GetByGuid(paymentSubmissionDto.Guid);
        var oldImageUrl = "";

        if (registerPaymentByGuid == null)
        {
            return -7;
        }

        if (registerPaymentByGuid.PaymentImage != "")
        {
            oldImageUrl = registerPaymentByGuid.PaymentImage;
        }


        var randomName = GenerateHandler.GenerateRandomString();
        var fileName = randomName + paymentSubmissionDto.PaymentImage.FileName;
        var imageUrl = $"images/register_payments/{fileName}";

        var filePath = $"{folderPath}\\{fileName}";
        using var transaction = _twizDbContext.Database.BeginTransaction();
        try
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await paymentSubmissionDto.PaymentImage.CopyToAsync(stream);
            }

            //// update payment image
            //bool paymentImageUpdated = _registerPaymentRepository.UpdatePaymentImage(paymentSubmissionDto.Guid, imageUrl);
            //if (!paymentImageUpdated)
            //{

            //    FileHandler.DeleteFileIfExist(filePath);
            //    return -4;
            //}

            //// update status payment
            //bool statusPaymentUpdated = _registerPaymentRepository.ChangeStatusRegisterPayment(paymentSubmissionDto.Guid, StatusPayment.Checking);

            //if (!statusPaymentUpdated)
            //{
            //    FileHandler.DeleteFileIfExist(filePath);
            //    return -5;
            //}

            registerPaymentByGuid.PaymentImage = imageUrl;
            registerPaymentByGuid.StatusPayment = StatusPayment.Checking;

            var updatedRegisterPayment = _registerPaymentRepository.Update(registerPaymentByGuid);

            if (updatedRegisterPayment == false)
            {
                FileHandler.DeleteFileIfExist(filePath);
                return -5;
            };


            // hapus foto lama jika ada
            if (oldImageUrl != "")
            {
                var filePathOldImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", oldImageUrl.Replace("/", "\\"));
                FileHandler.DeleteFileIfExist(filePathOldImage);
            }
        }
        catch
        {
            transaction.Rollback();

            FileHandler.DeleteFileIfExist(filePath);
            return -4;
        }

        try
        {
            var contentEmail = $"" +
                $"<h1>Register Payment Submission</h1>" +
                $"<p>Company Name : {companyName}</p>" +
                $"<p>Virtual Account : {registerPaymentByGuid.VaNumber}</p>" +
                $"<p>Now you can check it</p>";

            var emailAdmin = _accountService.GetEmailSysAdmin();


            _emailHandler.SendEmail(_accountService.GetEmailSysAdmin(), "Register Payment Submission", contentEmail);
        }
        catch
        {
            FileHandler.DeleteFileIfExist(filePath);
            transaction.Rollback();
            return -6;
        }

        transaction.Commit();


        return 1;
    }

    public int AproveRegisterPayment(AproveRegisterPaymentDto aproveRegisterPaymentDto)
    {
        using var transaction = _twizDbContext.Database.BeginTransaction();

        var getRegisterPayment = _registerPaymentRepository.GetByGuid(aproveRegisterPaymentDto.Guid);

        if (getRegisterPayment == null)
        {
            return 0;
        }

        getRegisterPayment.IsValid = true;
        getRegisterPayment.StatusPayment = StatusPayment.Paid;
        getRegisterPayment.ModifiedDate = DateTime.Now;

        var registerPaymentUpdated = _registerPaymentRepository.Update(getRegisterPayment);

        if (registerPaymentUpdated is false)
        {
            transaction.Rollback();
            return 0;
        }

        var getAccountCompany = _accountRepository.GetByEmail(aproveRegisterPaymentDto.CompanyEmail);

        if (getAccountCompany is null)
        {
            transaction.Rollback();
            return 0;
        }

        // aktivasi account
        getAccountCompany.IsActive = true;

        var accountUpdated = _accountRepository.Update(getAccountCompany);

        if (accountUpdated is false)
        {
            transaction.Rollback();
            return 0;
        }


        try
        {
            var contentEmail = $"<h1>Conratulation Your Account Has Been Activated!!</h1>" +
                $"<p>welcome to tWiz. Now you can fully use the services of our tWiz service. Don't hesitate to contact the support center if you have any problems using our tWiz service</p>";

            _emailHandler.SendEmail(aproveRegisterPaymentDto.CompanyEmail, "Aproved tWiz Account", contentEmail);
            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            return 0;
        }

        return 1;
    }

    public int RejectRegisterPayment(AproveRegisterPaymentDto aproveRegisterPaymentDto)
    {
        using var transaction = _twizDbContext.Database.BeginTransaction();

        var getRegisterPayment = _registerPaymentRepository.GetByGuid(aproveRegisterPaymentDto.Guid);

        if (getRegisterPayment == null)
        {
            return 0;
        }

        getRegisterPayment.IsValid = false;
        getRegisterPayment.StatusPayment = StatusPayment.Pending;
        getRegisterPayment.ModifiedDate = DateTime.Now;

        var registerPaymentUpdated = _registerPaymentRepository.Update(getRegisterPayment);

        if (registerPaymentUpdated is false)
        {
            transaction.Rollback();
            return 0;
        }

        var getAccountCompany = _accountRepository.GetByEmail(aproveRegisterPaymentDto.CompanyEmail);

        if (getAccountCompany is null)
        {
            transaction.Rollback();
            return 0;
        }

        // aktivasi account
        getAccountCompany.IsActive = false;

        var accountUpdated = _accountRepository.Update(getAccountCompany);

        if (accountUpdated is false)
        {
            transaction.Rollback();
            return 0;
        }

        try
        {
            var contentEmail = $"<h1>Your Submission is Rejected</h1>" +
                $"<p>For customers. Sorry, we still can't activate your tWiz account because the proof of payment that you uploaded is invalid</p>";

            _emailHandler.SendEmail(aproveRegisterPaymentDto.CompanyEmail, "Reject activation tWiz Account", contentEmail);
            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            return 0;
        }

        return 1;
    }

}
