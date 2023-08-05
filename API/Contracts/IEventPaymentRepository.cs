using API.Models;

namespace API.Contracts;

public interface IEventPaymentRepository : IGeneralRepository<EventPayment>
{
    public bool Deletes(List<EventPayment> eventPayments);
    public bool Creates(List<EventPayment> eventPayments);
}
