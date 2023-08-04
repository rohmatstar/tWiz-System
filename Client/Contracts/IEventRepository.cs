using Client.DTOs;
using Client.DTOs.Events;

namespace Client.Contracts;

public interface IEventRepository : IRepository<EventsDto, Guid>
{
    public Task<ResponseListDto<GetEventDto>> Getall();
}
