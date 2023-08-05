using API.Contracts;
using API.DTOs.Accounts;
using API.Models;
using API.Utilities.Handlers;

namespace API.Services;

public class AccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IEmailHandler _emailhandler;
    private readonly IAccountRoleRepository _accountRoleRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly ISysAdminRepository _sysAdminRepository;


    public AccountService(IAccountRepository accountRepository, IEmailHandler emailhandler, IAccountRoleRepository accountRoleRepository, IRoleRepository roleRepository, ISysAdminRepository sysAdminRepository)
    {
        _accountRepository = accountRepository;
        _emailhandler = emailhandler;
        _accountRoleRepository = accountRoleRepository;
        _roleRepository = roleRepository;
        _sysAdminRepository = sysAdminRepository;
    }

    public IEnumerable<GetAccountDto>? GetAccounts()
    {
        var accounts = _accountRepository.GetAll();
        if (accounts is null)
        {
            return null;
        }

        var toDto = accounts.Select(account =>
                                            new GetAccountDto
                                            {
                                                Guid = account.Guid,
                                                Email = account.Email,
                                                Password = account.Password,
                                                IsActive = account.IsActive,
                                                Token = account.Token,
                                                TokenIsUsed = account.TokenIsUsed,
                                                TokenExpiration = account.TokenExpiration,
                                            }).ToList();

        return toDto; // Account found
    }

    public GetAccountDto? GetAccount(Guid guid)
    {
        var account = _accountRepository.GetByGuid(guid);
        if (account is null)
        {
            return null; // account not found
        }

        var toDto = new GetAccountDto
        {
            Guid = account.Guid,
            Email = account.Email,
            Password = account.Password,
            IsActive = account.IsActive,
            Token = account.Token,
            TokenIsUsed = account.TokenIsUsed,
            TokenExpiration = account.TokenExpiration,
        };

        return toDto; // accounts found
    }

    public CreatedAccountDto? CreateAccount(CreateAccountDto createAccountDto)
    {
        var account = new Account
        {
            Guid = new Guid(),
            Email = createAccountDto.Email,
            Password = HashingHandler.HashPassword(createAccountDto.Password),
            IsActive = createAccountDto.IsActive,
            Token = null,
            TokenIsUsed = null,
            TokenExpiration = null,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };

        var createdAccount = _accountRepository.Create(account);
        if (createdAccount is null)
        {
            return null; // Account not created
        }

        var toDto = new CreatedAccountDto
        {
            Guid = createdAccount.Guid,
            Email = createdAccount.Email,
            IsActive = createdAccount.IsActive,
        };

        return toDto; // Account created
    }

    public int UpdateAccount(UpdateAccountDto updateAccountDto)
    {
        var isExist = _accountRepository.IsExist(updateAccountDto.Guid);
        if (!isExist)
        {
            return -1; // Account not found
        }

        var getAccount = _accountRepository.GetByGuid(updateAccountDto.Guid);

        var account = new Account
        {
            Guid = updateAccountDto.Guid,
            Email = updateAccountDto.Email,
            Password = HashingHandler.HashPassword(updateAccountDto.Password),
            IsActive = updateAccountDto.IsActive,
            Token = updateAccountDto.Token ?? null,
            TokenIsUsed = updateAccountDto.TokenIsUsed ?? null,
            TokenExpiration = updateAccountDto.TokenExpiration ?? null,
            ModifiedDate = DateTime.Now,
            CreatedDate = getAccount!.CreatedDate,
        };

        var isUpdate = _accountRepository.Update(account);
        if (!isUpdate)
        {
            return 0; // Account not updated
        }

        return 1;
    }

    public int ActivateDeactivate(Guid guid)
    {
        var isExist = _accountRepository.IsExist(guid);
        if (!isExist)
        {
            return -1; // Account not found
        }

        var getAccount = _accountRepository.GetByGuid(guid);

        var account = new Account
        {
            Guid = getAccount!.Guid,
            Email = getAccount.Email,
            Password = getAccount.Password,
            IsActive = !getAccount.IsActive,
            Token = getAccount.Token ?? null,
            TokenIsUsed = getAccount.TokenIsUsed ?? null,
            TokenExpiration = getAccount.TokenExpiration ?? null,
            ModifiedDate = DateTime.Now,
            CreatedDate = getAccount!.CreatedDate,
        };

        var isUpdate = _accountRepository.Update(account);
        if (!isUpdate)
        {
            return 0; // Account not updated
        }

        return 1;
    }

    public int DeleteAccount(Guid guid)
    {
        var isExist = _accountRepository.IsExist(guid);
        if (!isExist)
        {
            return -1; // Account not found
        }

        var account = _accountRepository.GetByGuid(guid);
        var isDelete = _accountRepository.Delete(account!);
        if (!isDelete)
        {
            return 0; // Account not deleted
        }

        return 1;
    }

    public string GetEmailSysAdmin()
    {
        //var emailSysAdmin = (from account in GetAccounts()
        //                     join accountRole in _accountRoleRepository.GetAll()
        //                     on account.Guid equals accountRole.AccountGuid
        //                     join role in _roleRepository.GetAll()
        //                     on accountRole.RoleGuid equals role.Guid
        //                     where role.Name == nameof(RoleLevel.SysAdmin)
        //                     select account.Email
        //              ).FirstOrDefault();

        //if (emailSysAdmin == null)
        //{
        //    return "";
        //}

        var sysAdmin = _sysAdminRepository.GetAll().ToList()[0];

        var accountSysAdmin = _accountRepository.GetByGuid(sysAdmin.AccountGuid);

        return accountSysAdmin?.Email ?? "";
    }
}

