

using API.DTOs.Employees;

namespace Client.Contracts;

public interface IEmployeeRepository : IRepository<GetEmployeeDto,Guid>
{   
}
