using API.DTOs.Employees;
using API.Repositories;
using Client.Contracts;

namespace Client.Reopositories
{
    public class EmployeeRepository : GeneralRepository<GetEmployeeDto, Guid>, IEmployeeRepository
    {
        public EmployeeRepository(string request = "employees/") : base(request)
        {
        }
    }
}
