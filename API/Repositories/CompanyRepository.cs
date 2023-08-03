using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class CompanyRepository : GeneralRepository<Company>, ICompanyRepository
{
    public CompanyRepository(TwizDbContext context) : base(context)
    {
    }

    public Company? GetByName(string name)
    {
        return _context.Set<Company>().FirstOrDefault(company => company.Name == name);
    }
}
