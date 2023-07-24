using API.DTOs.Banks;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("api/banks")]
public class BankController : ControllerBase
{
    private readonly BankService _service;

    public BankController(BankService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var entities = _service.GetBanks();

        if (entities == null)
        {
            return NotFound(new ResponseHandler<GetBankDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data not found"
            });
        }

        return Ok(new ResponseHandler<IEnumerable<GetBankDto>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Data found",
            Data = entities
        });
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var bank = _service.GetBank(guid);
        if (bank is null)
        {
            return NotFound(new ResponseHandler<GetBankDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data not found"
            });
        }

        return Ok(new ResponseHandler<GetBankDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Data found",
            Data = bank
        });
    }

    [HttpPost]
    public IActionResult Create(CreateBankDto newBankDto)
    {
        var createBank = _service.CreateBank(newBankDto);
        if (createBank is null)
        {
            return BadRequest(new ResponseHandler<GetBankDto>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Data not created"
            });
        }

        return Ok(new ResponseHandler<GetBankDto>
        {
            Code = StatusCodes.Status201Created,
            Status = HttpStatusCode.Created.ToString(),
            Message = "Successfully created",
            Data = createBank
        });
    }

    [HttpPut]
    public IActionResult Update(UpdateBankDto updateBankDto)
    {
        var update = _service.UpdateBank(updateBankDto);
        if (update is -1)
        {
            return NotFound(new ResponseHandler<UpdateBankDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found"
            });
        }
        if (update is 0)
        {
            return BadRequest(new ResponseHandler<UpdateBankDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Check your data"
            });
        }
        return Ok(new ResponseHandler<UpdateBankDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully updated"
        });
    }

    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var delete = _service.DeleteBank(guid);

        if (delete is -1)
        {
            return NotFound(new ResponseHandler<GetBankDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found"
            });
        }
        if (delete is 0)
        {
            return BadRequest(new ResponseHandler<GetBankDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Check connection to database"
            });
        }

        return Ok(new ResponseHandler<GetBankDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully deleted"
        });
    }
}

