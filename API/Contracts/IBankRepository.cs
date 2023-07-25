using API.Models;

namespace API.Contracts;

public interface IBankRepository : IGeneralRepository<Bank>
{
    Bank? GetByName(string name);
}
