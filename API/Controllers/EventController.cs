﻿using Microsoft.AspNetCore.Mvc;
using System.Net;
using API.DTOs.Events;
using API.Utilities.Handlers;
using API.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventController : ControllerBase
    {
        private readonly EventService _eventService;

        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            var eventsData = _eventService.GetAll();
            if (eventsData != null)
            {
                return Ok(new ResponseHandler<IEnumerable<EventsDto>>
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
            var eventsData = _eventService.GetSingle(guid);
            if (eventsData != null)
            {
                return Ok(new ResponseHandler<EventsDto>
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
    }
}
