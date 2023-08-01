using API.Models;

namespace API.Contracts;

public interface IEmployeeRepository : IGeneralRepository<Employee>
{
    IEnumerable<Employee> GetByFirstName(string name);
    IEnumerable<Employee> GetName(Guid fkAccountGuid);
}
