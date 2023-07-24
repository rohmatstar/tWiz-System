using API.Contracts;
using API.DTOs.Accounts;
using API.Models;
using API.Utilities.Handlers;

namespace API.Services;

public class AccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public IEnumerable<GetAccountDto>? GetAccounts()
    {
        var accounts = _accountRepository.GetAll();
        if (!accounts.Any())
        {
            return null; // No Account  found
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

    public GetAccountDto? CreateAccount(CreateAccountDto newAccountDto)
    {
        var account = new Account
        {
            Guid = Guid.NewGuid(),
            Email = newAccountDto.Email,
            Password = HashingHandler.HashPassword(newAccountDto.Password),
            IsActive = newAccountDto.IsActive,
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

        var toDto = new GetAccountDto
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
}

