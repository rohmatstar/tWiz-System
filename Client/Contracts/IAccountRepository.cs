using Client.DTOs;
using Client.DTOs.Accounts;
using Client.Models;

namespace Client.Contracts
{
    public interface IAccountRepository : IRepository<GetAccountDto, Guid>
    {
        public Task<ResponseListDto<GetAccountDto>> GetAccount();
    }
}
