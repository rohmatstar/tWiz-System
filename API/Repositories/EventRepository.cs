using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class EventRepository : GeneralRepository<Event>, IEventRepository
{
    public EventRepository(TwizDbContext context) : base(context)
    {
    }
}
