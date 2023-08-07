using API.DTOs.Events;
using API.Services;
using API.Utilities.Enums;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("api/events")]
[Authorize]
public class EventController : ControllerBase
{
    private readonly EventService _eventService;

    public EventController(EventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public IActionResult GetEvents([FromQuery] QueryParamGetEventDto queryParams)
    {
        var eventsData = _eventService.GetEvents(queryParams);
        if (eventsData != null)
        {
            return Ok(new ResponseHandler<IEnumerable<GetEventDto>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = eventsData
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

    [HttpGet("statistic")]
    public IActionResult GetEventsStatistic()
    {
        var eventsData = _eventService.GetEventsStatistic();
        if (eventsData != null)
        {
            return Ok(new ResponseHandler<IEnumerable<GetEventDto>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = eventsData
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
        var eventsData = _eventService.GetEvent(guid);
        if (eventsData != null)
        {
            return Ok(new ResponseHandler<GetEventDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = eventsData
            });
        }

        return NotFound(new ResponseHandler<EventsDto>
        {
            Code = StatusCodes.Status404NotFound,
            Status = HttpStatusCode.NotFound.ToString(),
            Message = "You cannot access it",
            Data = null
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateEventDto createEventsDto)
    {
        var createdEvent = await _eventService.CreateEvent(createEventsDto);
        if (createdEvent is -1)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<string>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Failed create folder image"
            });
        }

        if (createdEvent is -2)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseHandler<string>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "File size cannot be more than 2mb"
            });
        }

        if (createdEvent is -3)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseHandler<string>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "your uploaded file is not image file"
            });
        }

        if (createdEvent is 0)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseHandler<string>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.Unauthorized.ToString(),
                Message = "Not Authenticated"
            });
        }

        return Ok(new ResponseHandler<string>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully created event"
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromForm] UpdateEventDto updateEventDto)
    {
        var updatedEvent = await _eventService.UpdateEvent(updateEventDto);
        if (updatedEvent is -1)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<string>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Failed create folder image"
            });
        }

        if (updatedEvent is -2)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseHandler<string>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "File size cannot be more than 2mb"
            });
        }

        if (updatedEvent is -3)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseHandler<string>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "your uploaded file is not image file"
            });
        }

        if (updatedEvent is -4)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseHandler<string>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "failed to delete old event image"
            });
        }

        if (updatedEvent is 0)
        {
            return StatusCode(StatusCodes.Status401Unauthorized, new ResponseHandler<string>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.Unauthorized.ToString(),
                Message = "Not Authenticated"
            });
        }

        return Ok(new ResponseHandler<string>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully created event"
        });
    }

    [HttpDelete]
    public IActionResult DeleteEvent(Guid guid)
    {
        var deleted = _eventService.DeleteEvent(guid);
        if (deleted is not null)
        {
            return Ok(new ResponseHandler<EventsDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Successfully to deleted event",
                Data = deleted
            });
        }

        return NotFound(new ResponseHandler<EventsDto>
        {
            Code = StatusCodes.Status404NotFound,
            Status = HttpStatusCode.NotFound.ToString(),
            Message = "Failed to Delete",
            Data = null
        });
    }

    [HttpGet("internal")]
    [Authorize(Roles = $"{nameof(RoleLevel.Company)}")]
    public IActionResult GetInternalEvents([FromQuery] QueryParamGetEventDto queryParams)
    {

        var internalEvents = _eventService.GetInternalEvents(queryParams);
        if (internalEvents is not null)
        {
            return Ok(new ResponseHandler<List<GetEventDto>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = internalEvents
            });
        }

        return StatusCode(StatusCodes.Status403Forbidden, new ResponseHandler<string>
        {
            Code = StatusCodes.Status403Forbidden,
            Status = HttpStatusCode.Forbidden.ToString(),
            Message = "You cannot access!!"
        });
    }

    [HttpPut("participants")]
    public IActionResult UpdateParticipantsEvent(UpdateParticipantsEventDto updateParticipantsEventDto)
    {
        var internalEvents = _eventService.UpdateParticipantsEvent(updateParticipantsEventDto);
        if (internalEvents != 0)
        {
            return Ok(new ResponseHandler<string>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
            });
        }

        return StatusCode(StatusCodes.Status400BadRequest, new ResponseHandler<string>
        {
            Code = StatusCodes.Status400BadRequest,
            Status = HttpStatusCode.BadRequest.ToString(),
            Message = "Check your data"
        });
    }

    [HttpPut("publish")]
    public IActionResult PublishEvent(Guid guid)
    {
        var result = _eventService.PublishEvent(guid);
        if (result != "0")
        {
            return Ok(new ResponseHandler<string>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = result // result = nama event
            });
        }

        return StatusCode(StatusCodes.Status400BadRequest, new ResponseHandler<string>
        {
            Code = StatusCodes.Status400BadRequest,
            Status = HttpStatusCode.BadRequest.ToString(),
            Message = "Check your data",
            Data = null
        });
    }

    [HttpGet("participants")]
    public IActionResult GetParticipantsEvent(Guid eventGuid)
    {
        var result = _eventService.GetParticipantsEvent(eventGuid);
        if (result != null)
        {
            return Ok(new ResponseHandler<GetParticipantsEventDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = result // result = nama event
            });
        }

        return StatusCode(StatusCodes.Status400BadRequest, new ResponseHandler<string>
        {
            Code = StatusCodes.Status400BadRequest,
            Status = HttpStatusCode.BadRequest.ToString(),
            Message = "Check your data",
            Data = null
        });
    }

    [HttpGet("invitation")]
    public IActionResult GetInvitationEvent([FromQuery] QueryParamGetEventDto queryParams)
    {
        var result = _eventService.GetInvitationEvents(queryParams);
        if (result != null)
        {
            return Ok(new ResponseHandler<List<GetInvitationEventDto>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = result
            });
        }

        return StatusCode(StatusCodes.Status400BadRequest, new ResponseHandler<string>
        {
            Code = StatusCodes.Status400BadRequest,
            Status = HttpStatusCode.BadRequest.ToString(),
            Message = "Check your data",
            Data = null
        });
    }

    [HttpGet("tickets")]
    public IActionResult GetTickets([FromQuery] QueryParamGetTicketDto queryParams)
    {
        var personalEvents = _eventService.GetTickets(queryParams);
        if (personalEvents is not null)
        {
            return Ok(new ResponseHandler<List<TicketDto>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = personalEvents
            });
        }

        return StatusCode(StatusCodes.Status403Forbidden, new ResponseHandler<string>
        {
            Code = StatusCodes.Status403Forbidden,
            Status = HttpStatusCode.Forbidden.ToString(),
            Message = "You cannot access!!"
        });
    }

    [HttpPut("approve-event")]
    public IActionResult ApproveParticipantEvent(Guid eventGuid)
    {
        var personalEvents = _eventService.ApproveEvent(eventGuid);
        if (personalEvents is not 0)
        {
            return Ok(new ResponseHandler<string>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
            });
        }

        return StatusCode(StatusCodes.Status400BadRequest, new ResponseHandler<string>
        {
            Code = StatusCodes.Status400BadRequest,
            Status = HttpStatusCode.BadRequest.ToString(),
            Message = "You cannot access!!"
        });
    }

    [HttpPut("reject-event")]
    public IActionResult RejectEvent(Guid eventGuid)
    {
        var personalEvents = _eventService.RejectEvent(eventGuid);
        if (personalEvents is not 0)
        {
            return Ok(new ResponseHandler<string>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
            });
        }

        return StatusCode(StatusCodes.Status400BadRequest, new ResponseHandler<string>
        {
            Code = StatusCodes.Status400BadRequest,
            Status = HttpStatusCode.BadRequest.ToString(),
            Message = "You cannot access!!"
        });
    }

    [HttpGet("company-published-paid-event")]
    public IActionResult GetCompanyPaidEvent()
    {
        var companyPaidEvents = _eventService.GetCompanyPaidEvent();
        if (companyPaidEvents is not null)
        {
            return Ok(new ResponseHandler<List<GetEventDto>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = companyPaidEvents
            });
        }

        return StatusCode(StatusCodes.Status404NotFound, new ResponseHandler<string>
        {
            Code = StatusCodes.Status404NotFound,
            Status = HttpStatusCode.NotFound.ToString(),
            Message = "Data Not Found!",
            Data = null
        });
    }
}

