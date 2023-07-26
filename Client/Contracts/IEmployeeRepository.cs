using Client.DTOs;

namespace Client.Contracts;

public interface IEmployeeRepository : IRepository<GetMasterEmployeeDtoClient,Guid>
{   
}
