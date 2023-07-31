using API.Contracts;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Utilities;

public class TokenHandlers : ITokenHandlers
{
    private readonly IConfiguration _configuration;

    public TokenHandlers(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(IEnumerable<Claim> claims)
    {
        var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTService:Key"]));

        var signinCredentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);

        var tokenOptions = new JwtSecurityToken(
            issuer: _configuration["JWTService:Issuer"],

            audience: _configuration["JWTService:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: signinCredentials);

        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return tokenString;
    }
}
