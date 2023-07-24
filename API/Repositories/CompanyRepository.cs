using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class CompanyRepository : GeneralRepository<Company> , ICompanyRepository
{
    public CompanyRepository(TwizDbContext context) : base(context)
    {
    }
}
