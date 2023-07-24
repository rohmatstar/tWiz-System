using API.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using API.DTOs.Events;
using API.Utilities.Handlers;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            var data = _eventRepository.GetAll();
            if (data != null && data.Any())
            {
                return Ok(new ResponseHandler<IEnumerable<EventsDto>>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Success",
                    Data = data
                });
            }

            return NotFound(new ResponseHandler<EventsDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Not Found",
                Data = null
            });
        }

        [HttpGet("{guid}")]
        public IActionResult GetEvent(Guid guid)
        {
            var data = _eventRepository.GetSingle(guid);
            if (data != null && data.Any())
            {
                return Ok(new ResponseHandler<IEnumerable<EventsDto>>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Success",
                    Data = data
                });
            }

            return NotFound(new ResponseHandler<EventsDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Not Found",
                Data = null
            });
        }
    }
}
