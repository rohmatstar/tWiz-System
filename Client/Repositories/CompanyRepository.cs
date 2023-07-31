using Client.Contracts;
using Client.DTOs.Companies;

namespace Client.Repositories
{
    public class CompanyRepository : GeneralRepository<GetCompanyDto, Guid>, ICompanyRepository
    {
        public CompanyRepository(string request = "companies/") : base(request)
        {
        }
    }
}
