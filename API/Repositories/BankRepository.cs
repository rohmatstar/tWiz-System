using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class BankRepository : GeneralRepository<Bank>, IBankRepository
{
    public BankRepository(TwizDbContext context) : base(context)
    {
    }

    public Bank? GetByName(string name)
    {
        return _context.Set<Bank>().FirstOrDefault(x => x.Name == name);
    }
}
