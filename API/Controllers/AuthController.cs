using API.DTOs.Auths;
using API.DTOs.Companies;
using API.DTOs.RegisterPayments;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;


[ApiController]
[Route("api/auths")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;
    private readonly RegisterPaymentService _paymentService;

    public AuthController(AuthService authService, RegisterPaymentService paymentService)
    {
        _authService = authService;
        _paymentService = paymentService;
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

        if (login is "-1" || login is "0")
        {
            return NotFound(new ResponseHandler<LoginDto>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Email or password is wrong"
            });
        }

        if (login is "-2")
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<LoginDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Internal server error"
            });
        }

        if (login is "-3")
        {
            var payment = _paymentService.GetPaymentSummary(loginDto.Email);

            if (payment is null)
            {
                return StatusCode(StatusCodes.Status402PaymentRequired, new ResponseHandler<PaymentSummaryDto>
                {
                    Code = StatusCodes.Status204NoContent,
                    Status = HttpStatusCode.NoContent.ToString(),
                    Message = "Payment of this registered account is not found",
                });
            }
            else
            {
                return StatusCode(StatusCodes.Status402PaymentRequired, new ResponseHandler<PaymentSummaryDto>
                {
                    Code = StatusCodes.Status402PaymentRequired,
                    Status = HttpStatusCode.PaymentRequired.ToString(),
                    Message = "Sorry your account is inactive, please do the payment to activate",
                    /*Data = payment*/
                });
            }
        }

        return Ok(new ResponseHandler<String>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully login",
            Data = login // token
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
