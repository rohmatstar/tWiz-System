using API.DTOs.RegisterPayments;
using API.Services;
using API.Utilities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;


[ApiController]
[Route("api/registerpayments")]
public class RegisterPaymentController : ControllerBase
{
    private readonly RegisterPaymentService _service;
    
    public RegisterPaymentController(RegisterPaymentService service)
    {
        _service = service;
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        var entities = _service.GetRegisterPayments();

        if (entities == null)
        {
            return NotFound(new ResponseHandler<GetRegisterPaymentDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data not found"
            });
        }

        return Ok(new ResponseHandler<IEnumerable<GetRegisterPaymentDto>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Data found",
            Data = entities
        });
    }

    [HttpGet("{guid}")]
    [AllowAnonymous]
    public IActionResult GetByGuid(Guid guid)
    {
        var registerpayment = _service.GetRegisterPayment(guid);
        if (registerpayment is null)
        {
            return NotFound(new ResponseHandler<GetRegisterPaymentDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data not found"
            });
        }

        return Ok(new ResponseHandler<GetRegisterPaymentDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Data found",
            Data = registerpayment
        });
    }

    [HttpPost]
    public IActionResult Create(CreateRegisterPaymentDto newRegisterPaymentDto)
    {
        var createEventPayment = _service.CreateEventPayment(newRegisterPaymentDto);
        if (createEventPayment is null)
        {
            return BadRequest(new ResponseHandler<GetRegisterPaymentDto>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Data not created"
            });
        }

        return Ok(new ResponseHandler<GetRegisterPaymentDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully created",
            Data = createEventPayment
        });
    }

    [HttpPut]
    public IActionResult Update(UpdateRegisterPaymentDto updateRegisterPaymentDto)
    {
        var update = _service.UpdateRegisterPayment(updateRegisterPaymentDto);
        if (update is -1)
        {
            return NotFound(new ResponseHandler<UpdateRegisterPaymentDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found"
            });
        }
        if (update is 0)
        {
            return BadRequest(new ResponseHandler<UpdateRegisterPaymentDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Check your data"
            });
        }
        return Ok(new ResponseHandler<UpdateRegisterPaymentDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully updated"
        });
    }

    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var delete = _service.DeleteRegisterPayment(guid);

        if (delete is -1)
        {
            return NotFound(new ResponseHandler<GetRegisterPaymentDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found"
            });
        }
        if (delete is 0)
        {
            return BadRequest(new ResponseHandler<GetRegisterPaymentDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Check connection to database"
            });
        }

        return Ok(new ResponseHandler<GetRegisterPaymentDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully deleted"
        });
    }

    [HttpPost("payment")]
    [AllowAnonymous]
    public IActionResult Payment(string email)
    {
        var generateOtp = _service.Payment(email);
        if (generateOtp is null)
        {
            return BadRequest(new ResponseHandler<PaymentDto>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Email Not Found"
            });
        }

        return Ok(new ResponseHandler<PaymentDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Virtual Number Is Generated",
            Data = generateOtp
        });
    }
}
