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
        try
        {
            _context.Set<EmployeeParticipant>().RemoveRange(employeeParticipants);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
