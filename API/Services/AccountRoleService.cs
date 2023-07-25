using API.Contracts;
using API.DTOs.AccountRoles;
using API.Models;

namespace API.Services
{
    public class AccountRoleService
    {
        private readonly IAccountRoleRepository _accountRoleRepository;

        public AccountRoleService(IAccountRoleRepository accountRoleRepository)
        {
            _accountRoleRepository = accountRoleRepository;
        }

        public IEnumerable<GetAccountRoleDto>? GetAccountRoles()
        {
            var accountRoles = _accountRoleRepository.GetAll();
            if (!accountRoles.Any())
            {
                return null; // No Account Role found
            }

            var toDto = accountRoles.Select(accountRole =>
                                                new GetAccountRoleDto
                                                {
                                                    Guid = accountRole.Guid,
                                                    AccountGuid = accountRole.AccountGuid,
                                                    RoleGuid = accountRole.RoleGuid,
                                                }).ToList();

            return toDto; // Account Role found
        }

        public GetAccountRoleDto? GetAccountRole(Guid guid)
        {
            var accountRole = _accountRoleRepository.GetByGuid(guid);
            if (accountRole is null)
            {
                return null; // accountRole not found
            }

            var toDto = new GetAccountRoleDto
            {
                Guid = accountRole.Guid,
                AccountGuid = accountRole.AccountGuid,
                RoleGuid = accountRole.RoleGuid,
            };

            return toDto; // Universities found
        }

        public GetAccountRoleDto? CreateAccountRole(CreateAccountRoleDto newAccountRoleDto)
        {
            var accountRole = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = newAccountRoleDto.AccountGuid,
                RoleGuid = newAccountRoleDto.RoleGuid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var createdAccountRole = _accountRoleRepository.Create(accountRole);
            if (createdAccountRole is null)
            {
                return null; // Account Role not created
            }

            var toDto = new GetAccountRoleDto
            {
                Guid = createdAccountRole.Guid,
                AccountGuid = createdAccountRole.AccountGuid,
                RoleGuid = createdAccountRole.RoleGuid,
            };

            return toDto; // Account Role created
        }

        public int UpdateAccountRole(UpdateAccountRoleDto updateAccountRole)
        {
            var isExist = _accountRoleRepository.IsExist(updateAccountRole.Guid);
            if (!isExist)
            {
                return -1; // Account Role not found
            }

            var getAccountRole = _accountRoleRepository.GetByGuid(updateAccountRole.Guid);

            var accountRole = new AccountRole
            {
                Guid = updateAccountRole.Guid,
                AccountGuid = updateAccountRole.AccountGuid,
                RoleGuid = updateAccountRole.RoleGuid,
                ModifiedDate = DateTime.Now,
                CreatedDate = getAccountRole!.CreatedDate
            };

            var isUpdate = _accountRoleRepository.Update(accountRole);
            if (!isUpdate)
            {
                return 0; // Account Role not updated
            }

            return 1;
        }

        public int DeleteAccountRole(Guid guid)
        {
            var isExist = _accountRoleRepository.IsExist(guid);
            if (!isExist)
            {
                return -1; // Account Role not found
            }

            var accountRole = _accountRoleRepository.GetByGuid(guid);
            var isDelete = _accountRoleRepository.Delete(accountRole!);
            if (!isDelete)
            {
                return 0; // Account Role not deleted
            }

            return 1;
        }
    }
}
