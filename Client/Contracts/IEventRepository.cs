using Client.DTOs;
using Client.DTOs.Events;

namespace Client.Contracts;

public interface IEventRepository : IRepository<EventsDto, Guid>
{
    public Task<ResponseListDto<GetEventDto>> Getall();
    public Task<ResponseListDto<GetEventDto>> GetInternal(QueryParamGetEventDto queryParams);
    public Task<ResponseDto<GetEventDto>> GetEvent(Guid guid);

    public Task<ResponseDto<GetParticipantsEventDto>> GetParticipantsEvent(Guid guid);

    public Task<ResponseListDto<GetInvitationEventDto>> GetInvitationEvents(QueryParamGetEventDto queryParams);
}
