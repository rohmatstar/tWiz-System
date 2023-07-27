using System.Security.Claims;

namespace Client.Contracts
{
    public interface ITokenHandler
    {
        public string GenerateToken(IEnumerable<Claim> claims);
    }
}
