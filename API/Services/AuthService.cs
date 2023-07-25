using API.Contracts;
using API.Data;
using API.DTOs.Auths;
using API.Models;
using API.Utilities.Enums;
using API.Utilities.Handlers;
using System.Security.Claims;

namespace API.Services;

public class AuthService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IRegisterPaymentRepository _registerPaymentRepository;
    private readonly IAccountRoleRepository _accountRoleRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly ITokenHandlers _tokenHandler;
    private readonly TwizDbContext _twizDbContext;
    private readonly IEmailHandler _emailHandler;
    private readonly IBankRepository _bankRepository;

    public AuthService(IAccountRepository accountRepository, 
        ICompanyRepository companyRepository, 
        IEmployeeRepository employeeRepository, 
        IRegisterPaymentRepository registerPaymentRepository, 
        IAccountRoleRepository accountRoleRepository, 
        IRoleRepository roleRepository, 
        ITokenHandlers tokenHandler, 
        TwizDbContext twizDbContext, 
        IEmailHandler emailHandler,
        IBankRepository bankRepository)
    {
        _accountRepository = accountRepository;
        _companyRepository = companyRepository;
        _employeeRepository = employeeRepository;
        _registerPaymentRepository = registerPaymentRepository;
        _accountRoleRepository = accountRoleRepository;
        _roleRepository = roleRepository;
        _tokenHandler = tokenHandler;
        _twizDbContext = twizDbContext;
        _emailHandler = emailHandler;
        _bankRepository = bankRepository;
    }

    public RegisterDto? Register(RegisterDto registerDto)
    {
        using var transaction = _twizDbContext.Database.BeginTransaction();
        try
        {
            Account account = new Account
            {
                Guid = new Guid(),
                Email = registerDto.Email,
                Password = HashingHandler.HashPassword(registerDto.Password),
                IsActive = false,
                Token = null,
                TokenIsUsed = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                TokenExpiration = null,
                ConfirmPassword = registerDto.ConfirmPassword
            };

            var createdAccount = _accountRepository.Create(account);
            if (createdAccount is null)
            {
                return null;
            }

            Company company = new Company
            {
                Guid = new Guid(),
                AccountGuid = createdAccount.Guid,
                Name = registerDto.Name,
                Address = registerDto.Address,
                PhoneNumber = registerDto.PhoneNumber,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var createdCompany = _companyRepository.Create(company);
            if (createdCompany is null)
            {
                return null;
            }

            var getRoleUser = _roleRepository.GetByName(nameof(RoleLevel.Company));
            if (getRoleUser is null)
            {
                return null;
            }
            var accountRole =_accountRoleRepository.Create(new AccountRole
            {
                AccountGuid = account.Guid,
                RoleGuid = getRoleUser.Guid
            });

            if (accountRole is null)
            {
                return null;
            }

            var getBank = _bankRepository.GetByName("Bank Rakyat Indonesia");
            if (getBank is null)
            {
                return null;
            }

            RegisterPayment registerPayment = new RegisterPayment 
            {
                CompanyGuid = createdCompany.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                Price = 100000,
                PaymentImage = "",
                IsValid = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                BankGuid = getBank.Guid
            };

            var createdRegisterPayment = _registerPaymentRepository.Create(registerPayment);
            if (createdRegisterPayment is null)
            {
                return null;
            }

            var toDto = new RegisterDto
            {
                Name = createdCompany.Name,
                Email = createdAccount.Email,
                PhoneNumber = createdCompany.PhoneNumber,
                Password = createdAccount.Password,
                Address = createdCompany.Address,
                ConfirmPassword = createdAccount.Password
            };

            transaction.Commit();
            return toDto;
        }
        catch (Exception)
        {
            transaction.Rollback();
            return null;
        }
    }

   /* public string Login(LoginDto login)
    {
        var emailEmp = _employeeRepository.GetByEmail(login.Email);
        if (emailEmp == null)
        {
            return "0";
        }

        var pass = _accountRepository.GetByGuid(emailEmp.Guid);
        if (pass == null)
        {
            return "0";
        }
        var isPasswordValid = Hashing.ValidatePassword(login.Password, pass.Password);
        if (!isPasswordValid)
        {
            return "-1";
        }


        var claims = new List<Claim>()
            {
                new Claim("Nik", emailEmp.Nik),
                new Claim("FullName", $"{emailEmp.FirstName} {emailEmp.LastName}"),
                new Claim("Email", login.Email)
            };

        var getAccountRole = _accountRoleRepository.GetByGuidEmployee(emailEmp.Guid);
        var getRoleNameByAccountRole = from ar in getAccountRole
                                       join r in _roleRepository.GetAll() on ar.RoleGuid equals r.Guid
                                       select r.Name;

        claims.AddRange(getRoleNameByAccountRole.Select(role => new Claim(ClaimTypes.Role, role)));
        try
        {
            var getToken = _tokenHandler.GenerateToken(claims);
            return getToken;
        }
        catch
        {
            return "-2";
        }
    }

    public int ChangePassword(ChangePasswordDto changePasswordDto)
    {
        var isExist = _employeeRepository.CheckEmail(changePasswordDto.Email);
        if (isExist is null)
        {
            return -1; //Account Not Found
        }

        var getAccount = _accountRepository.GetByGuid(isExist.Guid);
        if (getAccount.Otp != changePasswordDto.Otp)
        {
            return 0;
        }

        if (getAccount.IsUsed == true)
        {
            return 1;
        }
        if (getAccount.ExpiredTime < DateTime.Now)
        {
            return 2;
        }

        var account = new Account
        {
            Guid = getAccount.Guid,
            IsUsed = getAccount.IsUsed,
            IsDeleted = getAccount.IsDeleted,
            ModifiedDate = getAccount.ModifiedDate,
            CreatedDate = getAccount.CreatedDate,
            Otp = getAccount.Otp,
            ExpiredTime = getAccount.ExpiredTime,
            Password = Hashing.HashPassword(changePasswordDto.NewPassword)
        };

        var isUpdate = _accountRepository.Update(account);
        if (!isUpdate)
        {
            return 0; // Account not updated
        }

        return 3;
    }
    public ForgotPasswordDto ForgotPassword(string email)
    {
        var employee = _employeeRepository.GetAll().SingleOrDefault(account => account.Email == email);
        if (employee is null)
        {
            return null;
        }

        var toDto = new ForgotPasswordDto
        {
            Email = employee.Email,
            Otp = GenerateOTP.GenerateRandomOTP(),
            ExpiredTime = DateTime.Now.AddMinutes(5)
        };

        var relatedAccount = _accountRepository.GetByGuid(employee.Guid);

        var update = new Account
        {
            Guid = relatedAccount.Guid,
            Password = relatedAccount.Password,
            IsDeleted = relatedAccount.IsDeleted,
            Otp = toDto.Otp,
            IsUsed = false,
            ExpiredTime = DateTime.Now.AddMinutes(5)

        };

        var updateResult = _accountRepository.Update(update);

        _emailHandler.SendEmail(toDto.Email,
                       "Forgot Password",
                       $"Your OTP is {toDto.Otp}");

        return toDto;
    }*/
}
