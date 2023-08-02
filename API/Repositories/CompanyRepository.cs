using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class CompanyRepository : GeneralRepository<Company>, ICompanyRepository
{
    public CompanyRepository(TwizDbContext context) : base(context)
    {
    }

    //public IEnumerable<Company> GetName(Guid fkAccountGuid)
    //{
    //    return _context.Set<Company>().Where(company => company.AccountGuid == fkAccountGuid);
    //}
}
