using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class EventRepository : GeneralRepository<Event>, IEventRepository
{
    public EventRepository(TwizDbContext context) : base(context) { }

    //public new EventsDto? GetByGuid(Guid guid)
    //{
    //    return _context.Set<EventsDto>().Find(guid);
    //}

    public IEnumerable<Event> GetEventsByCreatedBy(Guid companyGuid)
    {
        return _context.Set<Event>().Where(e => e.CreatedBy == companyGuid);

    }
}
