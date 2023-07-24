using API.Models;
using API.DTOs.Events;

namespace API.Contracts;

public interface IEventRepository : IGeneralRepository<Event>
{
    new IEnumerable<EventsDto>? GetAll();
    IEnumerable<EventsDto>? GetSingle(Guid guid);
    EventsDto? CreateEvent(CreateEventDto createEventDto);
    EventsDto? UpdateEvent(EventsDto eventsDto);
    EventsDto? DeleteEvent(Guid guid);
}
