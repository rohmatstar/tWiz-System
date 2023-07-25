using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class AccountRepository : GeneralRepository<Account>, IAccountRepository
{
    public AccountRepository(TwizDbContext context) : base(context)
    {
    }

    public Account? GetByEmail(string email)
    {
        return _context.Set<Account>().FirstOrDefault(e => e.Email == email);
    }

    public Account? CheckEmail(string email)
    {
        return _context.Set<Account>().FirstOrDefault(e => e.Email == email);
    }
/*
    public Account? GetByEmailAndPhoneNumber(string data)
    {
        return _context.Set<Account>().FirstOrDefault(e => e.PhoneNumber == data || e.Email == data);
    }*/
}
