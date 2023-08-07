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
    private readonly IHttpContextAccessor _httpContextAccessor;

    private readonly IRegisterPaymentRepository _registerPaymentRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IBankRepository _bankRepository;
    private readonly IEmailHandler _emailHandler;
    private readonly AccountService _accountService;
    private readonly TwizDbContext _twizDbContext;
    public RegisterPaymentService(IRegisterPaymentRepository registerPaymentRepository, ICompanyRepository companyRepository, IAccountRepository accountRepository, IBankRepository bankRepository, IEmailHandler emailHandler, AccountService accountService, TwizDbContext twizDbContext, IHttpContextAccessor httpContextAccessor)
    {
        _registerPaymentRepository = registerPaymentRepository;
        _companyRepository = companyRepository;
        _accountRepository = accountRepository;
        _bankRepository = bankRepository;
        _emailHandler = emailHandler;
        _accountService = accountService;
        _twizDbContext = twizDbContext;
        _httpContextAccessor = httpContextAccessor;
        _bankRepository = bankRepository;
    }

    public IEnumerable<GetRegisterPaymentDto>? GetRegisterPayments()
    {
        var registerPayments = _registerPaymentRepository.GetAll();
        if (registerPayments is null)
        {
            return null; // No RegisterPayment Found
        }

        var companies = _companyRepository.GetAll();
        var banks = _bankRepository.GetAll();
        var accounts = _accountRepository.GetAll();

        var toDto = registerPayments.Select(rp =>
        {
            var company = companies.FirstOrDefault(c => c.Guid == rp.CompanyGuid);
            var accountCompany = accounts.FirstOrDefault(acc => acc.Guid == company.AccountGuid);
            var bank = banks.FirstOrDefault(b => b.Guid == rp.BankGuid);

            var statusPayment = "";
            if (rp.StatusPayment == StatusPayment.Pending) statusPayment = "pending";
            if (rp.StatusPayment == StatusPayment.Checking) statusPayment = "checking";
            if (rp.StatusPayment == StatusPayment.Paid) statusPayment = "paid";
            if (rp.StatusPayment == StatusPayment.Rejected) statusPayment = "rejected";


            return new GetRegisterPaymentDto
            {
                Guid = rp.Guid,
                VaNumber = rp.VaNumber,
                CompanyEmail = accountCompany?.Email ?? "",
                CompanyName = company?.Name ?? "",
                PaymentImage = rp.PaymentImage,
                Price = rp.Price,
                StatusPayment = statusPayment,
                ValidationStatus = rp.IsValid == true ? "valid" : "invalid",
                BankName = bank?.Name ?? ""
            };
        });


        return toDto;
    }

    public GetRegisterPaymentDto? GetRegisterPayment(Guid guid)
    {
        var claimUser = _httpContextAccessor.HttpContext?.User;

        var userRole = claimUser?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        var accountGuid = claimUser?.Claims?.FirstOrDefault(x => x.Type == "Guid")?.Value;

        if (accountGuid is null)
        {
            return null;
        }

        var registerPayments = _registerPaymentRepository.GetByGuid(guid);
        if (registerPayments is null)
        {
            return null;
        }

        var company = _companyRepository.GetAll().FirstOrDefault(c => c.Guid == registerPayments.CompanyGuid);

        if (company is null)
        {
            return null;
        }

        // jika user bukan sysadmin atau company yang punya register payment ini
        if (userRole != nameof(RoleLevel.SysAdmin) && Guid.Parse(accountGuid) != company.AccountGuid)
        {
            return null;
        }

        var accountCompany = _accountRepository.GetAll().FirstOrDefault(acc => acc.Guid == company.AccountGuid);


        var bank = _bankRepository.GetAll().FirstOrDefault(b => b.Guid == registerPayments.BankGuid);

        var statusPayment = "";
        if (registerPayments.StatusPayment == StatusPayment.Pending) statusPayment = "pending";
        if (registerPayments.StatusPayment == StatusPayment.Checking) statusPayment = "checking";
        if (registerPayments.StatusPayment == StatusPayment.Paid) statusPayment = "paid";
        if (registerPayments.StatusPayment == StatusPayment.Rejected) statusPayment = "rejected";

        var toDto = new GetRegisterPaymentDto
        {
            Guid = registerPayments.Guid,
            VaNumber = registerPayments.VaNumber,
            CompanyEmail = accountCompany?.Email ?? "",
            CompanyName = company?.Name ?? "",
            PaymentImage = registerPayments.PaymentImage,
            Price = registerPayments.Price,
            StatusPayment = statusPayment,
            ValidationStatus = registerPayments.IsValid == true ? "valid" : "invalid",
            BankName = bank?.Name ?? ""
        };

        return toDto;
    }

    public PaymentSummaryDto? GetPaymentSummary(string email)
    {
        var account = _accountRepository.GetByEmail(email);
        if (account is null)
        {
            return null;
        }
        var company = _companyRepository.GetAll().FirstOrDefault(c => c.AccountGuid == account!.Guid);
        if (company is null)
        {
            return null;
        }
        var payment = _registerPaymentRepository.GetAll().FirstOrDefault(c => c.CompanyGuid == company!.Guid);
        if (payment is null)
        {
            return null;
        }
        var bank = _bankRepository.GetAll().FirstOrDefault(c => c.Guid == payment!.BankGuid);
        if (bank is null)
        {
            return null;
        }

        if (payment.StatusPayment == StatusPayment.Paid)
        {
            var paid = new PaymentSummaryDto
            {
                VaNumber = 0,
                Price = 0,
                BankCode = null,
                BankName = null
            };
            return paid;
        }

        var toDto = new PaymentSummaryDto
        {
            Guid = payment.Guid,
            VaNumber = payment.VaNumber,
            Price = payment.Price,
            BankCode = bank.Code,
            BankName = bank.Name
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
            //CompanyGuid = createdRegisterPayment.CompanyGuid,
            VaNumber = createdRegisterPayment.VaNumber,
            Price = createdRegisterPayment.Price,
            PaymentImage = createdRegisterPayment.PaymentImage,
            //IsValid = createdRegisterPayment.IsValid,
            //BankGuid = createdRegisterPayment.BankGuid,
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
        if(paymentSubmissionDto.PaymentImage is null)
        {
            return -1;
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
        var imageUrl = $"{fileName}";

        var filePath = $"{folderPath}\\{fileName}";
        using var transaction = _twizDbContext.Database.BeginTransaction();
        try
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await paymentSubmissionDto.PaymentImage.CopyToAsync(stream);
            }

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
            var company = _companyRepository.GetByGuid(registerPaymentByGuid.CompanyGuid);

            if (company == null)
            {
                FileHandler.DeleteFileIfExist(filePath);
                transaction.Rollback();
                return -7;
            }

            var contentEmail = $"" +
                $"<h1>Register Payment Submission</h1>" +
                $"<p>Company Name : {company.Name}</p>" +
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

        var company = _companyRepository.GetAll().FirstOrDefault(c => c.Guid == getRegisterPayment.CompanyGuid);

        if (company is null)
        {
            transaction.Rollback();
            return 0;
        }

        var accountCompany = _accountRepository.GetAll().FirstOrDefault(acc => acc.Guid == company.AccountGuid);

        if (accountCompany is null)
        {
            transaction.Rollback();
            return 0;
        }

        // aktivasi account
        accountCompany.IsActive = true;

        var accountUpdated = _accountRepository.Update(accountCompany);

        if (accountUpdated is false)
        {
            transaction.Rollback();
            return 0;
        }


        try
        {
            var contentEmail = $"<h1>Conratulation Your Account Has Been Activated!!</h1>" +
                $"<p>welcome to tWiz. Now you can fully use the services of our tWiz service. Don't hesitate to contact the support center if you have any problems using our tWiz service</p>";

            _emailHandler.SendEmail(accountCompany.Email, "Aproved tWiz Account", contentEmail);
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

        var company = _companyRepository.GetAll().FirstOrDefault(c => c.Guid == getRegisterPayment.CompanyGuid);

        if (company is null)
        {
            transaction.Rollback();
            return 0;
        }

        var accountCompany = _accountRepository.GetAll().FirstOrDefault(acc => acc.Guid == company.AccountGuid);

        if (accountCompany is null)
        {
            transaction.Rollback();
            return 0;
        }

        // aktivasi account
        accountCompany.IsActive = true;

        var accountUpdated = _accountRepository.Update(accountCompany);

        if (accountUpdated is false)
        {
            transaction.Rollback();
            return 0;
        }

        try
        {
            var contentEmail = $"<h1>Your Submission is Rejected</h1>" +
                $"<p>For customers. Sorry, we still can't activate your tWiz account because the proof of payment that you uploaded is invalid</p>";

            _emailHandler.SendEmail(accountCompany.Email, "Reject activation tWiz Account", contentEmail);
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
