using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class EventPaymentRepository : GeneralRepository<EventPayment>, IEventPaymentRepository
{
    public EventPaymentRepository(TwizDbContext context) : base(context)
    {
    }
}
