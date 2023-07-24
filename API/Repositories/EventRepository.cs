using API.Contracts;
using API.Data;
using API.Models;
using API.DTOs.Events;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class EventRepository : GeneralRepository<Event>, IEventRepository
{
    public EventRepository(TwizDbContext context) : base(context)
    {
    }

    public new IEnumerable<EventsDto>? GetAll()
    {
        var events = _context.Events.Select(e => new EventsDto
        {
            Guid = e.Guid,
            Name = e.Name,
            Thumbnail = e.Thumbnail,
            Description = e.Description,
            IsPublished = e.IsPublished,
            IsPaid = e.IsPaid,
            Price = e.Price,
            Category = e.Category,
            Status = e.Status,
            StartDate = e.StartDate,
            EndDate = e.EndDate,
            Quota = e.Quota,
            Place = e.Place,
            CreatedBy = e.CreatedBy
        }).ToList();

        return events;
    }

    public IEnumerable<EventsDto>? GetSingle(Guid guid)
    {
        var events = _context.Events.Where(e => e.Guid == guid).Select(e => new EventsDto
        {
            Guid = e.Guid,
            Name = e.Name,
            Thumbnail = e.Thumbnail,
            Description = e.Description,
            IsPublished = e.IsPublished,
            IsPaid = e.IsPaid,
            Price = e.Price,
            Category = e.Category,
            Status = e.Status,
            StartDate = e.StartDate,
            EndDate = e.EndDate,
            Quota = e.Quota,
            Place = e.Place,
            CreatedBy = e.CreatedBy
        }).ToList();

        return events;
    }

    public EventsDto? CreateEvent(CreateEventDto createEventDto)
    {
        var eventModel = new Event
        {
            Guid = new Guid(),
            Name = createEventDto.Name!,
            Thumbnail = createEventDto.Thumbnail,
            Description = createEventDto.Description!,
            IsPublished = (bool)createEventDto.IsPublished!,
            IsPaid = (bool)createEventDto.IsPaid!,
            Price = createEventDto.Price,
            Category = createEventDto.Category!,
            Status = createEventDto.Status,
            StartDate = createEventDto.StartDate,
            EndDate = createEventDto.EndDate,
            Quota = (int)createEventDto.Quota!,
            Place = createEventDto.Place!,
            CreatedBy = createEventDto.CreatedBy
        };

        _context.Events.Add(eventModel);
        _context.SaveChanges();

        var createdEvent = new EventsDto
        {
            Guid = eventModel.Guid,
            Name = eventModel.Name!,
            Thumbnail = eventModel.Thumbnail,
            Description = eventModel.Description!,
            IsPublished = (bool)eventModel.IsPublished!,
            IsPaid = (bool)eventModel.IsPaid!,
            Price = eventModel.Price,
            Category = eventModel.Category!,
            Status = eventModel.Status,
            StartDate = eventModel.StartDate,
            EndDate = eventModel.EndDate,
            Quota = (int)eventModel.Quota!,
            Place = eventModel.Place!,
            CreatedBy = eventModel.CreatedBy
        };

        return createdEvent;
    }

    public EventsDto? UpdateEvent(EventsDto eventsDto)
    {
        var singleEvent = _context.Events.Find(eventsDto.Guid);
        if (singleEvent == null)
        {
            return null;
        }

        singleEvent.Name = eventsDto.Name!;
        singleEvent.Thumbnail = eventsDto.Thumbnail;
        singleEvent.Description = eventsDto.Description!;
        singleEvent.IsPublished = (bool)eventsDto.IsPublished!;
        singleEvent.IsPaid = (bool)eventsDto.IsPaid!;
        singleEvent.Price = eventsDto.Price;
        singleEvent.Category = eventsDto.Category!;
        singleEvent.Status = eventsDto.Status;
        singleEvent.StartDate = eventsDto.StartDate;
        singleEvent.EndDate = eventsDto.EndDate;
        singleEvent.Quota = (int)eventsDto.Quota!;
        singleEvent.Place = eventsDto.Place!;
        singleEvent.CreatedBy = eventsDto.CreatedBy;

        _context.SaveChanges();

        var updatedEvent = new EventsDto
        {
            Guid = singleEvent.Guid,
            Name = singleEvent.Name!,
            Thumbnail = singleEvent.Thumbnail,
            Description = singleEvent.Description!,
            IsPublished = (bool)singleEvent.IsPublished!,
            IsPaid = (bool)singleEvent.IsPaid!,
            Price = singleEvent.Price,
            Category = singleEvent.Category!,
            Status = singleEvent.Status,
            StartDate = singleEvent.StartDate,
            EndDate = singleEvent.EndDate,
            Quota = (int)singleEvent.Quota!,
            Place = singleEvent.Place!,
            CreatedBy = singleEvent.CreatedBy
        };

        return updatedEvent;
    }
}
