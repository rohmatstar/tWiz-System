﻿using API.DTOs.Events;
using API.Services;
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

    [HttpGet("{guid}")]
    public IActionResult GetEvent(Guid guid, [FromQuery] string? usedfor)
    {
        var eventsData = _eventService.GetEvent(guid, usedfor);
        if (eventsData != null)
        {
            return Ok(new ResponseHandler<GetEventMasterDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = eventsData
            });
        }

        return NotFound(new ResponseHandler<EventsDto>
        {
            Code = StatusCodes.Status403Forbidden,
            Status = HttpStatusCode.Forbidden.ToString(),
            Message = "You cannot access it",
            Data = null
        });
    }

    [HttpPost]
    public IActionResult Create(CreateEventDto createEventsDto)
    {
        var created = _eventService.CreateEvent(createEventsDto);
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
        var updated = _eventService.UpdateEvent(eventsDto);
        if (updated is not null)
        {
            return Ok(new ResponseHandler<EventsDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success",
                Data = updated
            });
        }

        return NotFound(new ResponseHandler<EventsDto>
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
        var deleted = _eventService.DeleteEvent(guid);
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
            Message = "Failed to Delete",
            Data = null
        });
    }

    //[HttpGet("internal")]
    //[Authorize(Roles = $"{nameof(RoleLevel.Company)}, {nameof(RoleLevel.Employee)}")]
    //public IActionResult GetInternalEvents([FromQuery] string? type)
    //{
    //    // type = 'public' or 'personal'
    //    var internalEvents = _eventService.GetInternalEvents(type);
    //    if (internalEvents is not null)
    //    {
    //        return Ok(new ResponseHandler<List<EventsDto>>
    //        {
    //            Code = StatusCodes.Status200OK,
    //            Status = HttpStatusCode.OK.ToString(),
    //            Message = "Success",
    //            Data = internalEvents
    //        });
    //    }

    //    return StatusCode(StatusCodes.Status403Forbidden, new ResponseHandler<string>
    //    {
    //        Code = StatusCodes.Status403Forbidden,
    //        Status = HttpStatusCode.Forbidden.ToString(),
    //        Message = "You cannot access!!"
    //    });
    //}

    //[HttpGet("external")]
    //[Authorize(Roles = $"{nameof(RoleLevel.Company)}, {nameof(RoleLevel.Employee)}")]
    //public IActionResult GetExternalEvents([FromQuery] string? type)
    //{
    //    // type = 'public' or 'personal'
    //    var internalEvents = _eventService.GetExternalEvents(type);
    //    if (internalEvents is not null)
    //    {
    //        return Ok(new ResponseHandler<List<EventsDto>>
    //        {
    //            Code = StatusCodes.Status200OK,
    //            Status = HttpStatusCode.OK.ToString(),
    //            Message = "Success",
    //            Data = internalEvents
    //        });
    //    }

    //    return StatusCode(StatusCodes.Status403Forbidden, new ResponseHandler<string>
    //    {
    //        Code = StatusCodes.Status403Forbidden,
    //        Status = HttpStatusCode.Forbidden.ToString(),
    //        Message = "You cannot access!!"
    //    });
    //}

    //[HttpGet("public")]
    //[Authorize(Roles = $"{nameof(RoleLevel.Company)}, {nameof(RoleLevel.Employee)}")]
    //public IActionResult GetPublicEvents()
    //{

    //    var publicEvents = _eventService.GetPublicEvents();
    //    if (publicEvents is not null)
    //    {
    //        return Ok(new ResponseHandler<List<EventsDto>>
    //        {
    //            Code = StatusCodes.Status200OK,
    //            Status = HttpStatusCode.OK.ToString(),
    //            Message = "Success",
    //            Data = publicEvents
    //        });
    //    }

    //    return StatusCode(StatusCodes.Status403Forbidden, new ResponseHandler<string>
    //    {
    //        Code = StatusCodes.Status403Forbidden,
    //        Status = HttpStatusCode.Forbidden.ToString(),
    //        Message = "You cannot access!!"
    //    });
    //}

    //[HttpGet("personal")]
    //[Authorize(Roles = $"{nameof(RoleLevel.Company)}, {nameof(RoleLevel.Employee)}")]
    //public IActionResult GetPersonalEvents()
    //{

    //    var personalEvents = _eventService.GetPersonalEvents();
    //    if (personalEvents is not null)
    //    {
    //        return Ok(new ResponseHandler<List<EventsDto>>
    //        {
    //            Code = StatusCodes.Status200OK,
    //            Status = HttpStatusCode.OK.ToString(),
    //            Message = "Success",
    //            Data = personalEvents
    //        });
    //    }

    //    return StatusCode(StatusCodes.Status403Forbidden, new ResponseHandler<string>
    //    {
    //        Code = StatusCodes.Status403Forbidden,
    //        Status = HttpStatusCode.Forbidden.ToString(),
    //        Message = "You cannot access!!"
    //    });
    //}

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
}

