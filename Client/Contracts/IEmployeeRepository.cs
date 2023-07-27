using Client.DTOs.Employees;

namespace Client.Contracts;

public interface IEmployeeRepository : IRepository<GetMasterEmployeeDtoClient,Guid>
{   
}
