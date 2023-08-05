using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class EventPaymentRepository : GeneralRepository<EventPayment>, IEventPaymentRepository
{
    public EventPaymentRepository(TwizDbContext context) : base(context)
    {
    }

    public bool Deletes(List<EventPayment> eventPayments)
    {
        try
        {
            _context.Set<EventPayment>().RemoveRange(eventPayments);
            _context.SaveChanges();

            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Creates(List<EventPayment> eventPayments)
    {

        try
        {
            _context.Set<EventPayment>().AddRange(eventPayments);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

}
