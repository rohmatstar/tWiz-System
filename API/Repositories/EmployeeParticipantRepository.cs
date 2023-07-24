using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class EmployeeParticipantRepository : GeneralRepository<EmployeeParticipant>, IEmployeeParticipantRepository
{
    public EmployeeParticipantRepository(TwizDbContext context) : base(context)
    {
    }
}
