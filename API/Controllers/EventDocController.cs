using API.DTOs.EventDocs;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("api/event-documentations")]
    public class EventDocController : ControllerBase
    {
        private readonly EventDocService _eventDocService;

        public EventDocController(EventDocService eventDocService)
        {
            _eventDocService = eventDocService;
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            var eventsData = _eventDocService.GetEventDocs();
            if (eventsData != null || eventsData!.Any() || eventsData!.Count() > 0)
            {
                return Ok(new ResponseHandler<IEnumerable<EventDocsDto>>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Success",
                    Data = eventsData
                });
            }

            return NotFound(new ResponseHandler<EventDocsDto>
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
            var eventsData = _eventDocService.GetEventDoc(guid);
            if (eventsData != null)
            {
                return Ok(new ResponseHandler<EventDocsDto>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Success",
                    Data = eventsData
                });
            }

            return NotFound(new ResponseHandler<EventDocsDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Not Found",
                Data = null
            });
        }

        [HttpPost]
        public IActionResult Create(CreateEventDocDto createEventDocDto)
        {
            var created = _eventDocService.CreateEventDoc(createEventDocDto);
            if (created is not null)
            {
                return Ok(new ResponseHandler<EventDocsDto>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Success",
                    Data = created
                });
            }

            return NotFound(new ResponseHandler<EventDocsDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Not Found",
                Data = null
            });
        }

        [HttpPut]
        public IActionResult Update(EventDocsDto eventDocsDto)
        {
            var updated = _eventDocService.UpdateEventDoc(eventDocsDto);
            if (updated is not null)
            {
                return Ok(new ResponseHandler<EventDocsDto>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Success",
                    Data = updated
                });
            }

            return NotFound(new ResponseHandler<EventDocsDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Failed to Update",
                Data = null
            });
        }

        [HttpDelete]
        public IActionResult DeleteEvent(Guid guid)
        {
            var deleted = _eventDocService.DeleteEventDoc(guid);
            if (deleted is not null)
            {
                return Ok(new ResponseHandler<EventDocsDto>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Success",
                    Data = deleted
                });
            }

            return NotFound(new ResponseHandler<EventDocsDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Failed to Delete",
                Data = null
            });
        }
    }
}
