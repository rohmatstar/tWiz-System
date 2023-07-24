using API.DTOs.EmployeeParticipants;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using API.Utilities.Handlers;
using API.DTOs.Events;

namespace API.Controllers
{

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
            var data = _service.GetAll();
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
            var data = _service.GetSingle(guid);
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
            var created = _service.Create(create);
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
            var updated = _service.Update(update);
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
            var deleted = _service.Delete(guid);
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
    }
}
