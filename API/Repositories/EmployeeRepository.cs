using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class EmployeeRepository : GeneralRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(TwizDbContext context) : base(context)
    {
    }

    public IEnumerable<Employee> GetByFirstName(string name)
    {
        return _context.Set<Employee>().Where(employee => employee.FullName.Contains(name));
    }

}
