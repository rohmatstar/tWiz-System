using Client.DTOs;
using Client.DTOs.EventPayments;

namespace Client.Contracts;

public interface IEventPaymentRepository : IRepository<GetEventPaymentDto, Guid>
{
    public Task<ResponseDto<EventPaymentSummaryDto>> GetSummary(Guid guid);
}

