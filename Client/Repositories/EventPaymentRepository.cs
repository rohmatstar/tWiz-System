using Client.Contracts;
using Client.DTOs.EventPayments;

namespace Client.Repositories;

public class EventPaymentRepository : GeneralRepository<GetEventPaymentDto, Guid>, IEventPaymentRepository
{
    public EventPaymentRepository(string request = "event-payments") : base(request)
    {
    }
}

