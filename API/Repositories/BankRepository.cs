using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class BankRepository : GeneralRepository<Bank>, IBankRepository
{
    public BankRepository(TwizDbContext context) : base(context)
    {
    }
}
