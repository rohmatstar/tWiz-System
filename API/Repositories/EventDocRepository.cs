using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class EventDocRepository : GeneralRepository<EventDoc>, IEventDocRepository
{
    public EventDocRepository(TwizDbContext context) : base(context)
    {
    }
}
