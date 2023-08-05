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
    private readonly ISysAdminRepository _sysAdminRepository;
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
        IBankRepository bankRepository,
        ISysAdminRepository sysAdminRepository)
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
        _sysAdminRepository = sysAdminRepository;
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
            var accountRole = _accountRoleRepository.Create(new AccountRole
            {
                AccountGuid = account.Guid,
                RoleGuid = getRoleUser.Guid
            });

            if (accountRole is null)
            {
                return null;
            }

            var getBanks = _bankRepository.GetAll().ToList();
            if (getBanks is null || getBanks.Count == 0)
            {
                return null; // Atau tindakan lain jika daftar kosong.
            }

            Random random = new Random();
            int randomIndex = random.Next(0, getBanks.Count - 1); // Mendapatkan indeks acak dalam rentang [0, count-1].
            var randomBank = getBanks[randomIndex]; // Mendapatkan bank secara acak.

            RegisterPayment registerPayment = new RegisterPayment
            {
                CompanyGuid = createdCompany.Guid,
                VaNumber = GenerateHandler.GenerateVa(),
                Price = 14998000,
                PaymentImage = "",
                IsValid = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                StatusPayment = StatusPayment.Pending,
                BankGuid = randomBank.Guid
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

    public string Login(LoginDto loginDto)
    {
        /*var emailEmp = _employeeRepository.GetByEmail(login.Email);
        if (emailEmp == null)
        {
            return "0";
        }*/

        var account = _accountRepository.GetByEmail(loginDto.Email);
        if (account is null)
        {
            return "0"; // account not found
        }

        var isPasswordValid = HashingHandler.ValidatePassword(loginDto.Password, account.Password);
        if (!isPasswordValid)
        {
            return "-1"; // wrong password
        }

        var claims = new List<Claim>()
        {
            new Claim("Guid", account.Guid.ToString()),
            new Claim("IsActive", account.IsActive.ToString()),
            new Claim("Email", loginDto.Email)
        };

        //var getAccountName = _companyRepository.GetName(account.Guid);
        //if (getAccountName is null)
        //{
        //    getAccountName = (IEnumerable<Company>?)_employeeRepository.GetName(account.Guid);
        //}
        //var accountName = (from an in getAccountName select an.Name);

        //claims.AddRange(accountName.Select(name => new Claim(ClaimTypes.Name, name)));

        var company = _companyRepository.GetAll().FirstOrDefault(c => c.AccountGuid == account.Guid);
        var employee = _employeeRepository.GetAll().FirstOrDefault(e => e.AccountGuid == account.Guid);
        var sysAdmin = _sysAdminRepository.GetAll().FirstOrDefault(sa => sa.AccountGuid == account.Guid);

        if (company is not null)
        {
            claims.Add(new Claim(ClaimTypes.Name, company.Name));
            var payment = _registerPaymentRepository.GetAll().FirstOrDefault(c => c.CompanyGuid == company.Guid);

            if (payment == null || payment.StatusPayment != StatusPayment.Paid)
            {
                return "-3";
            }
        }
        else if (employee is not null)
        {
            claims.Add(new Claim(ClaimTypes.Name, employee.FullName));
        }
        else if (sysAdmin is not null)
        {
            claims.Add(new Claim(ClaimTypes.Name, sysAdmin.Name));
        }
        else
        {
            return "0";

            claims.Add(new Claim(ClaimTypes.Name, company.Name));
            claims.Add(new Claim("UserGuid", company.Guid.ToString())); // Add Company Guid to Check Register Payment when signed in
        }

        var getAccountRole = _accountRoleRepository.GetByGuidCompany(account.Guid);

        var getRoleNameByAccountRole = from ar in getAccountRole
                                       join r in _roleRepository.GetAll() on ar.RoleGuid equals r.Guid
                                       select r.Name;

        claims.AddRange(getRoleNameByAccountRole.Select(role => new Claim(ClaimTypes.Role, role)));

        try
        {
            var token = _tokenHandler.GenerateToken(claims);
            return token;
        }
        catch
        {
            return "-2"; // generate token is failed
        }
    }

    public int ChangePassword(ChangePasswordDto changePasswordDto)
    {
        var isExist = _accountRepository.CheckEmail(changePasswordDto.Email);
        if (isExist is null)
        {
            return -1; //Account Not Found
        }

        var getAccount = _accountRepository.GetByGuid(isExist.Guid);
        if (getAccount.Token != changePasswordDto.Token)
        {
            return 0;
        }

        if (getAccount.TokenIsUsed == true)
        {
            return 1;
        }
        if (getAccount.TokenExpiration < DateTime.Now)
        {
            return 2;
        }

        var account = new Account
        {
            Guid = getAccount.Guid,
            Email = getAccount.Email,
            IsActive = getAccount.IsActive,
            ModifiedDate = getAccount.ModifiedDate,
            CreatedDate = getAccount.CreatedDate,
            Token = getAccount.Token,
            TokenExpiration = getAccount.TokenExpiration,
            TokenIsUsed = getAccount.TokenIsUsed,
            Password = HashingHandler.HashPassword(changePasswordDto.NewPassword)
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
        var account = _accountRepository.GetByEmail(email);
        if (account is null)
        {
            return null;
        }

        var toDto = new ForgotPasswordDto
        {
            Email = account.Email,
            Token = GenerateHandler.GenerateToken(),
            TokenExpiration = DateTime.Now.AddMinutes(5)
        };

        var relatedAccount = _accountRepository.GetByGuid(account.Guid);

        var update = new Account
        {
            Guid = relatedAccount.Guid,
            Email = relatedAccount.Email,
            Password = relatedAccount.Password,
            Token = toDto.Token,
            IsActive = relatedAccount.IsActive,
            TokenIsUsed = relatedAccount.TokenIsUsed,
            TokenExpiration = DateTime.Now.AddMinutes(5)

        };

        var updateResult = _accountRepository.Update(update);

        if (!updateResult)
        {
            return null;
        }

        _emailHandler.SendEmail(toDto.Email,
                       "Register Payment",
                       $"Your Virtual Account Number is {toDto.Token}, <a href='https://localhost:7153/?Token={toDto.Token}'>Klik Disini</a>");

        return toDto;
    }
}
