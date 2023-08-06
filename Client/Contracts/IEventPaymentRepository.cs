using Client.DTOs.EventPayments;

namespace Client.Contracts;

public interface IEventPaymentRepository : IRepository<GetEventPaymentDto, Guid>
{
}

