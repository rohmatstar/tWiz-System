using Client.DTOs.Events;

namespace Client.Contracts;

public interface IEventRepository : IRepository<EventsDto, Guid>
{
}
