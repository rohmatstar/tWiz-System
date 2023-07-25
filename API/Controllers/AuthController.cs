using API.DTOs.Auths;
using API.DTOs.Companies;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace API.Controllers;


[ApiController]
[Route("api/auths")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public ActionResult Register(RegisterDto registerDto)
    {
        var createRegister = _authService.Register(registerDto);
        if (createRegister is null)
        {
            return BadRequest(new ResponseHandler<GetCompanyDto>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Data not created"
            });
        }

        return Ok(new ResponseHandler<RegisterDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully created",
            Data = createRegister
        });
    }

	[HttpPost("login")]
	public ActionResult Login(LoginDto loginDto)
	{
		var result = _authService.Login(loginDto);
		if (result == "0")
		{
			return BadRequest(new ResponseHandler<LoginDto>
			{
				Code = StatusCodes.Status400BadRequest,
				Status = HttpStatusCode.BadRequest.ToString(),
				Message = "No Account Found"
			});
		}
		if (result == "-1")
		{
			return BadRequest(new ResponseHandler<LoginDto>
			{
				Code = StatusCodes.Status400BadRequest,
				Status = HttpStatusCode.BadRequest.ToString(),
				Message = "Wrong Password"
			});
		}


		return Ok(new
		{
			Code = StatusCodes.Status400BadRequest,
			Status = HttpStatusCode.BadRequest.ToString(),
			Message = "Login Success!",
			Data = result
		});
	}

}
