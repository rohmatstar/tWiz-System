using API.Models;

namespace API.Contracts;

public interface IEmployeeParticipantRepository : IGeneralRepository<EmployeeParticipant>
{
    public bool Deletes(List<EmployeeParticipant> employeeParticipants);
    public bool Creates(List<EmployeeParticipant> employeeParticipants);
}
