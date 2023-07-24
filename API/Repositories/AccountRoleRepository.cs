using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class AccountRoleRepository : GeneralRepository<AccountRole>, IAccountRoleRepository
{
    public AccountRoleRepository(TwizDbContext context) : base(context)
    {

    }

    public IEnumerable<AccountRole> GetAccountRolesByAccountGuid(Guid guid)
    {
        return _context.Set<AccountRole>().Where(ar => ar.AccountGuid == guid);
    }
}
