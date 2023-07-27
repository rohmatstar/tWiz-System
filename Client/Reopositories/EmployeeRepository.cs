using Client.Contracts;
using Client.DTOs.Employees;

namespace Client.Reopositories
{
    public class EmployeeRepository : GeneralRepository<GetMasterEmployeeDtoClient, Guid>, IEmployeeRepository
    {
        public EmployeeRepository(string request = "employees/") : base(request)
        {
        }
    }
}
