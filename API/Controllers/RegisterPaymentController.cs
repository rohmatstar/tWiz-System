using API.DTOs.RegisterPayments;
using API.Services;
using API.Utilities.Handlers;
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
        var createEventPayment = _service.CreateRegisterPayment(newRegisterPaymentDto);
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



    [HttpPut("payment-submission")]
    public async Task<IActionResult> PaymentSubmission([FromForm] PaymentSubmissionDto paymentSubmissionDto)
    {

        var paymentSubmissionStatus = await _service.UploadPaymentSubmission(paymentSubmissionDto);

        if (paymentSubmissionStatus is -1)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<string>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Failed create folder image"
            });
        }

        if (paymentSubmissionStatus is -2)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseHandler<string>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "File size cannot be more than 2mb"
            });
        }

        if (paymentSubmissionStatus is -3)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseHandler<string>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "your uploaded file is not image file"
            });
        }

        if (paymentSubmissionStatus is -4)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<string>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Failed to update image payment"
            });
        }

        if (paymentSubmissionStatus is -5)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<string>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Failed to update status payment"
            });
        }

        if (paymentSubmissionStatus is -6)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<string>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Check your internet connection"
            });
        }

        return Ok(new ResponseHandler<string>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully update data"
        });

    }

    // Testing
    /* [HttpPost("payment")]
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
     }*/
}
