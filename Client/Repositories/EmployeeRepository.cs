using Client.Contracts;
using Client.DTOs.Employees;
using Client.Models;
using System.Net.Http;

namespace Client.Repositories
{
    public class EmployeeRepository : GeneralRepository<GetMasterEmployeeDtoClient, Guid> ,IEmployeeRepository
    {
        private readonly HttpClient httpClient;
        private readonly string request;
        public EmployeeRepository(string request = "employees/get-all-master/") : base(request)
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7249/api/")
            };
            this.request = request;
        }
    }
}
