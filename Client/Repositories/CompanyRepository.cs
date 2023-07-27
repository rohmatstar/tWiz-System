using Client.Contracts;
using Client.Models;

namespace Client.Repositories
{
    public class CompanyRepository : GeneralRepository<Company, Guid>, ICompanyRepository
    {
        public CompanyRepository(string request) : base(request)
        {
        }
    }
}
