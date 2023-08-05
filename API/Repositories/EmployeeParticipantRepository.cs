using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class EmployeeParticipantRepository : GeneralRepository<EmployeeParticipant>, IEmployeeParticipantRepository
{
    public EmployeeParticipantRepository(TwizDbContext context) : base(context)
    {
    }

    public bool Deletes(List<EmployeeParticipant> employeeParticipants)
    {
        var transaction = _context.Database.BeginTransaction();

        try
        {
            _context.Set<EmployeeParticipant>().RemoveRange(employeeParticipants);
            _context.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }

    public bool Creates(List<EmployeeParticipant> employeeParticipants)
    {
        var transaction = _context.Database.BeginTransaction();

        try
        {
            _context.Set<EmployeeParticipant>().AddRange(employeeParticipants);
            _context.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }
}
