using API.Models;

namespace API.Contracts;

public interface ICompanyRepository : IGeneralRepository<Company>
{
    IEnumerable<Company> GetName(Guid fkAccountGuid);
}
