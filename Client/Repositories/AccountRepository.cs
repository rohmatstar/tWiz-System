using Client.Contracts;
using Client.Models;

namespace Client.Repositories
{
    public class AccountRepositories : GeneralRepository<Account, Guid>, IAccountRepository
    {
        public AccountRepositories(string request) : base(request)
        {
        }
    }
}
