﻿using API.DTOs.EmployeeParticipants;
using API.Services;
using API.Utilities.Enums;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;


[ApiController]
[Route("api/events/participants/employees")]
public class EmployeeParticipantController : ControllerBase
{

    private readonly EmployeeParticipantService _service;

    public EmployeeParticipantController(EmployeeParticipantService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var data = _service.GetEmployeeParticipants();
        if (data != null)
        {
            return Ok(new ResponseHandler<IEnumerable<EmployeeParticipantsDto>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = data
            });
        }

        return NotFound(new ResponseHandler<EmployeeParticipantsDto>
        {
            Code = StatusCodes.Status404NotFound,
            Status = HttpStatusCode.NotFound.ToString(),
            Message = "Not Found",
            Data = null
        });
    }

    [HttpGet("{guid}")]
    public IActionResult GetSingle(Guid guid)
    {
        var data = _service.GetEmployeeParticipant(guid);
        if (data != null)
        {
            return Ok(new ResponseHandler<EmployeeParticipantsDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = data
            });
        }

        return NotFound(new ResponseHandler<EmployeeParticipantsDto>
        {
            Code = StatusCodes.Status404NotFound,
            Status = HttpStatusCode.NotFound.ToString(),
            Message = "Not Found",
            Data = null
        });
    }

    [HttpPost]
    public IActionResult Create(CreateEmployeeParticipantDto create)
    {
        var created = _service.CreateEmployeeParticipant(create);
        if (created is not null)
        {
            return Ok(new ResponseHandler<EmployeeParticipantsDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = created
            });
        }

        return NotFound(new ResponseHandler<EmployeeParticipantsDto>
        {
            Code = StatusCodes.Status404NotFound,
            Status = HttpStatusCode.NotFound.ToString(),
            Message = "Not Found",
            Data = null
        });
    }

    [HttpPut]
    public IActionResult Update(EmployeeParticipantsDto update)
    {
        var updated = _service.UpdateEmployeeParticipant(update);
        if (updated is not null)
        {
            return Ok(new ResponseHandler<EmployeeParticipantsDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = updated
            });
        }

        return NotFound(new ResponseHandler<EmployeeParticipantsDto>
        {
            Code = StatusCodes.Status404NotFound,
            Status = HttpStatusCode.NotFound.ToString(),
            Message = "Failed to Update",
            Data = null
        });
    }

    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var deleted = _service.DeleteEmployeeParticipant(guid);
        if (deleted is not null)
        {
            return Ok(new ResponseHandler<EmployeeParticipantsDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = deleted
            });
        }

        return NotFound(new ResponseHandler<EmployeeParticipantsDto>
        {
            Code = StatusCodes.Status404NotFound,
            Status = HttpStatusCode.NotFound.ToString(),
            Message = "Failed to Delete",
            Data = null
        });
    }

    [HttpGet("event")]
    [Authorize(Roles = $"{nameof(RoleLevel.Company)}, {nameof(RoleLevel.SysAdmin)}")]
    public IActionResult GetCompanyParticipantsByEvent([FromQuery] Guid guid)
    {
        var employeeParticipants = _service.GetEmployeeParticipantsByEvent(guid);
        if (employeeParticipants is not null)
        {
            return Ok(new ResponseHandler<List<GetEmployeeParticipantDto>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Data found",
                Data = employeeParticipants
            });
        }

        return NotFound(new ResponseHandler<string>
        {
            Code = StatusCodes.Status404NotFound,
            Status = HttpStatusCode.NotFound.ToString(),
            Message = "Data not found",
            Data = null
        });
    }

    [HttpPut("company-employee")]
    public IActionResult UpdateCompanyEmployeeParticipants(UpdateEmployeParticipantsDto updateEmployeParticipantsDto)
    {
        var created = _service.UpdateCompanyEmployeeParticipantsEvent(updateEmployeParticipantsDto);
        if (created != 0)
        {
            return Ok(new ResponseHandler<string>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
            });
        }

        return NotFound(new ResponseHandler<EmployeeParticipantsDto>
        {
            Code = StatusCodes.Status404NotFound,
            Status = HttpStatusCode.NotFound.ToString(),
            Message = "Failed to create",
        });
    }

}

