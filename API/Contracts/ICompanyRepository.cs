using API.Models;

namespace API.Contracts;

public interface ICompanyRepository : IGeneralRepository<Company>
{
    public Company? GetByName(string name);
}
