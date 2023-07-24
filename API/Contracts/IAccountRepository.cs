using API.Models;

namespace API.Contracts;

public interface IAccountRepository : IGeneralRepository<Account>
{
    public Account? GetByEmail(string email);
}
