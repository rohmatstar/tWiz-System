using API.Contracts;
using API.Data;
using API.Models;
using API.DTOs.Events;
using System.Collections.Generic;
using System.Linq;

namespace API.Repositories;

public class EventRepository : GeneralRepository<Event>, IEventRepository
{
    public EventRepository(TwizDbContext context) : base(context)
    {
    }

    public IEnumerable<EventsDto>? GetAll()
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
}
