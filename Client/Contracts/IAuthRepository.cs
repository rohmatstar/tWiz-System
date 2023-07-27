using Client.DTOs;
using Client.DTOs.Auths;
using Client.Models;

namespace Client.Contracts
{
    public interface IAuthRepository : IRepository<Account, string>
    {
        public Task<ResponseDto<string>> Login(LoginDto loginDto);
    }
}