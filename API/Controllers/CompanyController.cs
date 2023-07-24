using API.DTOs.Companies;
using API.Services;
using API.Utilities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("api/companies")]
public class CompanyController : ControllerBase
{
    private readonly CompanyService _service;

    public CompanyController(CompanyService companyService)
    {
        _service = companyService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var entities = _service.GetCompanies();

        if (entities == null)
        {
            return NotFound(new ResponseHandler<GetCompanyDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data not found"
            });
        }

        return Ok(new ResponseHandler<IEnumerable<GetCompanyDto>>
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
            var company = _service.GetCompany(guid);
            if (company is null)
            {
                return NotFound(new ResponseHandler<GetCompanyDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data not found"
                });
            }

            return Ok(new ResponseHandler<GetCompanyDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Data found",
                Data = company
            });
        }

        [HttpPost]
        public IActionResult Create(CreateCompanyDto newCompanyDto)
        {
            var createCompany = _service.CreateCompany(newCompanyDto);
            if (createCompany is null)
            {
                return BadRequest(new ResponseHandler<GetCompanyDto>
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Message = "Data not created"
                });
            }

            return Ok(new ResponseHandler<GetCompanyDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully created",
                Data = createCompany
            });
        }

        [HttpPut]
        public IActionResult Update(UpdateCompanyDto updateCompanyDto)
        {
            var update = _service.UpdateCompany(updateCompanyDto);
            if (update is -1)
            {
                return NotFound(new ResponseHandler<UpdateCompanyDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id not found"
                });
            }
            if (update is 0)
            {
                return BadRequest(new ResponseHandler<UpdateCompanyDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Check your data"
                });
            }
            return Ok(new ResponseHandler<UpdateCompanyDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully updated"
            });
        }

        [HttpDelete]
        public IActionResult Delete(Guid guid)
        {
            var delete = _service.DeleteCompany(guid);

            if (delete is -1)
            {
                return NotFound(new ResponseHandler<GetCompanyDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Id not found"
                });
            }
            if (delete is 0)
            {
                return BadRequest(new ResponseHandler<GetCompanyDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Check connection to database"
                });
            }

            return Ok(new ResponseHandler<GetCompanyDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully deleted"
            });
        }
    
}
