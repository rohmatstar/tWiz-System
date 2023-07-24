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
    public EventRepository(TwizDbContext context) : base(context) {}

    public new EventsDto? GetByGuid(Guid guid)
    {
        return _context.Set<EventsDto>().Find(guid);
    }
}
