﻿using API.DTOs.EventPayments;
using API.Services;
using API.Utilities.Enums;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;


[ApiController]
[Route("api/event-payments")]
[Authorize]
public class EventPaymentController : ControllerBase
{
    private readonly EventPaymentService _service;

    public EventPaymentController(EventPaymentService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var entities = _service.GetEventPayments();

        if (entities == null)
        {
            return NotFound(new ResponseHandler<GetEventPaymentDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data not found"
            });
        }

        return Ok(new ResponseHandler<IEnumerable<GetEventPaymentDto>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Data found",
            Data = entities
        });
    }

    [HttpGet("{guid}")]
    [Authorize(Roles = $"{nameof(RoleLevel.Company)}, {nameof(RoleLevel.Employee)}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var eventpayment = _service.GetEventPayment(guid);
        if (eventpayment is null)
        {
            return NotFound(new ResponseHandler<GetEventPaymentDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data not found"
            });
        }

        return Ok(new ResponseHandler<GetEventPaymentDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Data found",
            Data = eventpayment
        });
    }

    [HttpPost]
    public IActionResult Create(CreateEventPaymentDto newEventPaymentDto)
    {
        var createEventPayment = _service.CreateEventPayment(newEventPaymentDto);
        if (createEventPayment is null)
        {
            return BadRequest(new ResponseHandler<GetEventPaymentDto>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Data not created"
            });
        }

        return Ok(new ResponseHandler<GetEventPaymentDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully created",
            Data = createEventPayment
        });
    }

    [HttpPut]
    public IActionResult Update(UpdateEventPaymentDto updateEventPaymentDto)
    {
        var update = _service.UpdateEventPayment(updateEventPaymentDto);
        if (update is -1)
        {
            return NotFound(new ResponseHandler<UpdateEventPaymentDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found"
            });
        }
        if (update is 0)
        {
            return BadRequest(new ResponseHandler<UpdateEventPaymentDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Check your data"
            });
        }
        return Ok(new ResponseHandler<UpdateEventPaymentDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully updated"
        });
    }

    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var delete = _service.DeleteEventPayment(guid);

        if (delete is -1)
        {
            return NotFound(new ResponseHandler<GetEventPaymentDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found"
            });
        }
        if (delete is 0)
        {
            return BadRequest(new ResponseHandler<GetEventPaymentDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Check connection to database"
            });
        }

        return Ok(new ResponseHandler<GetEventPaymentDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully deleted"
        });
    }

    [HttpPut("payment-submission")]
    public async Task<IActionResult> EventPaymentSubmission([FromForm] EventPaymentSubmissionDto paymentSubmissionDto)
    {

        var paymentSubmissionStatus = await _service.UploadEventPaymentSubmission(paymentSubmissionDto);

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

    [HttpPut("aprove")]
    public IActionResult Aprove(AproveEventPaymentDto aproveEventPaymentDto)
    {
        var aprovedEventPaymentStatus = _service.AproveEventPayment(aproveEventPaymentDto);

        if (aprovedEventPaymentStatus is 0)
        {
            return BadRequest(new ResponseHandler<string>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Check your data"
            });
        }


        return Ok(new ResponseHandler<string>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully aprove event payment submission"
        });
    }
}
