using API.DTOs.CompanyParticipants;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
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
    }
}
