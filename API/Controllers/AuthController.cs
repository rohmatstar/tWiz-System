using API.DTOs.Auths;
using API.DTOs.Companies;
using API.Services;
using API.Utilities.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

}
