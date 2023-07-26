using API.DTOs.Auths;
using API.Models;
using Client.DTOs;

namespace Client.Contracts
{
    public interface IAuthRepository : IRepository<Account, string>
    {
        public Task<ResponseDto<string>> Login(LoginDto loginDto);
    }
}