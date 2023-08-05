using API.DTOs.CompanyParticipants;
using API.Services;
using API.Utilities.Enums;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("api/events/participants/companies")]
public class CompanyParticipantController : ControllerBase
{
    private readonly CompanyParticipantService _service;

    public CompanyParticipantController(CompanyParticipantService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var data = _service.GetCompanyParticipants();
        if (data != null)
        {
            return Ok(new ResponseHandler<IEnumerable<CompanyParticipantsDto>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = data
            });
        }

        return NotFound(new ResponseHandler<CompanyParticipantsDto>
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
        var data = _service.GetCompanyParticipant(guid);
        if (data != null)
        {
            return Ok(new ResponseHandler<CompanyParticipantsDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = data
            });
        }

        return NotFound(new ResponseHandler<CompanyParticipantsDto>
        {
            Code = StatusCodes.Status404NotFound,
            Status = HttpStatusCode.NotFound.ToString(),
            Message = "Not Found",
            Data = null
        });
    }

    [HttpPost]
    public IActionResult Create(CreateCompanyParticipantDto create)
    {
        var created = _service.CreateCompanyParticipant(create);
        if (created is not null)
        {
            return Ok(new ResponseHandler<CompanyParticipantsDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = created
            });
        }

        return NotFound(new ResponseHandler<CompanyParticipantsDto>
        {
            Code = StatusCodes.Status404NotFound,
            Status = HttpStatusCode.NotFound.ToString(),
            Message = "Not Found",
            Data = null
        });
    }
    [HttpPut]
    public IActionResult Update(CompanyParticipantsDto update)
    {
        var updated = _service.UpdateCompanyParticipant(update);
        if (updated is not null)
        {
            return Ok(new ResponseHandler<CompanyParticipantsDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = updated
            });
        }

        return NotFound(new ResponseHandler<CompanyParticipantsDto>
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
        var deleted = _service.DeleteCompanyParticipant(guid);
        if (deleted is not null)
        {
            return Ok(new ResponseHandler<CompanyParticipantsDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = deleted
            });
        }

        return NotFound(new ResponseHandler<CompanyParticipantsDto>
        {
            Code = StatusCodes.Status404NotFound,
            Status = HttpStatusCode.NotFound.ToString(),
            Message = "Failed to Delete",
            Data = null
        });
    }

    [HttpPut("many")]
    public IActionResult Many(GetCompanyParticipantsDto companyParticipantsDto)
    {
        var created = _service.RemoveThenCreateCompanyParticipant(companyParticipantsDto);
        if (created != 0)
        {
            return Ok(new ResponseHandler<string>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success update company participants",
            });
        }

        return NotFound(new ResponseHandler<string>
        {
            Code = StatusCodes.Status400BadRequest,
            Status = HttpStatusCode.BadRequest.ToString(),
            Message = "Failed update company participants",
        });
    }

    [HttpGet("event")]
    [Authorize(Roles = $"{nameof(RoleLevel.Company)}, {nameof(RoleLevel.SysAdmin)}")]
    public IActionResult GetCompanyParticipantsByEvent([FromQuery] Guid guid)
    {
        var companyParticipants = _service.GetCompanyParticipantsByEvent(guid);
        if (companyParticipants is not null)
        {
            return Ok(new ResponseHandler<List<GetCompanyParticipantDto>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Data found",
                Data = companyParticipants
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
}

