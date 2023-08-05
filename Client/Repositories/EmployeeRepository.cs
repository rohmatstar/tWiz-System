using Client.Contracts;
using Client.DTOs.Employees;

namespace Client.Repositories
{
    public class EmployeeRepository : GeneralRepository<GetMasterEmployeeDto, Guid>, IEmployeeRepository
    {

        public EmployeeRepository(string request = "employees/") : base(request)
        {
        }
    }
}
