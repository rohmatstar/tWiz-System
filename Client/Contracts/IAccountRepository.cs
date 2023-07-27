using Client.Models;

namespace Client.Contracts
{
    public interface IAccountRepository : IRepository<Account, Guid>
    {
    }
}
