using Client.DTOs;
using Client.DTOs.Employees;
using Client.Models;

namespace Client.Contracts;

public interface IEmployeeRepository : IRepository<GetMasterEmployeeDto, Guid>
{
    
}
