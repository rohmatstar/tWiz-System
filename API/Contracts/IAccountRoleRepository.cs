using API.Models;

namespace API.Contracts;

public interface IAccountRoleRepository : IGeneralRepository<AccountRole>
{
    public IEnumerable<AccountRole> GetAccountRolesByAccountGuid(Guid guid);
}
