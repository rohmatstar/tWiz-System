using Client.Contracts;
using Client.DTOs.Employees;
using Client.Models;

namespace Client.Repositories
{
    public class EmployeeRepository : GeneralRepository<GetMasterEmployeeDtoClient, Guid> ,IEmployeeRepository
    {
        public EmployeeRepository(string request = "employees/get-all-master/") : base(request)
        {
        }
    }
}
