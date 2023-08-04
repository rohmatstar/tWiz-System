using Client.Contracts;
using Client.DTOs.Events;

namespace Client.Repositories;

public class EventRepository : GeneralRepository<EventsDto, Guid>, IEventRepository
{

    public EventRepository(string request = "events") : base(request)
    {
    }
}

