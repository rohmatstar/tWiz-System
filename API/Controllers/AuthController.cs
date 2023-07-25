using API.DTOs.Auths;
using API.DTOs.Companies;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Authorization;
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
		var login = _authService.Login(loginDto);

        if (login is "-1")
        {
            return NotFound(new ResponseHandler<LoginDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Data null"
            });
        }

        if (login is "0")
        {
            return BadRequest(new ResponseHandler<LoginDto>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Data not created"
            });
        }
        if (login is "-2")
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<LoginDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Otp does not match"
            });
        }

        return Ok(new ResponseHandler<String>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully login",
            Data = login
        });
    }

    [HttpPut("change-password")]
    public IActionResult Update(ChangePasswordDto changePasswordDto)
    {
        var update = _authService.ChangePassword(changePasswordDto);
        if (update is -1)
        {
            return NotFound(new ResponseHandler<ChangePasswordDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Email Not Found"
            });
        }

        if (update is 0)
        {
            return NotFound(new ResponseHandler<ChangePasswordDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Token Doesn't Match"
            });
        }
        if (update is 1)
        {
            return NotFound(new ResponseHandler<ChangePasswordDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Token has been used"
            });
        }
        if (update is 2)
        {
            return NotFound(new ResponseHandler<ChangePasswordDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Token already expired"
            });
        }
        return Ok(new ResponseHandler<ChangePasswordDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully Updated"
        });
    }

    [HttpPost("forgot-password")]
    [AllowAnonymous]
    public IActionResult ForgotPassword(string email)
    {
        var generateOtp = _authService.ForgotPassword(email);
        if (generateOtp is null)
        {
            return BadRequest(new ResponseHandler<ForgotPasswordDto>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Email Not Found"
            });
        }

        return Ok(new ResponseHandler<ForgotPasswordDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Token is Generated",
            Data = generateOtp
        });
    }

}
