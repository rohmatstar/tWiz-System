using System.Security.Claims;

namespace API.Contracts
{
    public interface ITokenHandlers
    {
        public string GenerateToken(IEnumerable<Claim> claims);
    }
}
