using API.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using API.DTOs.Events;
using API.Utilities.Handlers;

namespace API.Controllers
{
    [ApiController]
    [Route("api/events")]
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

        [HttpPost]
        public IActionResult Create(CreateEventDto createEventsDto)
        {
            var created = _eventRepository.CreateEvent(createEventsDto);
            if (created is not null)
            {
                return Ok(new ResponseHandler<EventsDto>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Success",
                    Data = created
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

        [HttpPut]
        public IActionResult Update(EventsDto eventsDto)
        {
            var created = _eventRepository.UpdateEvent(eventsDto);
            if (created is not null)
            {
                return Ok(new ResponseHandler<EventsDto>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Success",
                    Data = created
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

        [HttpDelete]
        public IActionResult DeleteEvent(Guid guid)
        {
            var deleted = _eventRepository.DeleteEvent(guid);
            if (deleted is not null)
            {
                return Ok(new ResponseHandler<EventsDto>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Success",
                    Data = deleted
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
