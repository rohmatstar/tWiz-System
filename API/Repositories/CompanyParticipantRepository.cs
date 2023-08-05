using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class CompanyParticipantRepository : GeneralRepository<CompanyParticipant>, ICompanyParticipantRepository
{
    public CompanyParticipantRepository(TwizDbContext context) : base(context)
    {
    }

    public bool Deletes(List<CompanyParticipant> companyParticipants)
    {
        var transaction = _context.Database.BeginTransaction();

        try
        {
            _context.Set<CompanyParticipant>().RemoveRange(companyParticipants);
            _context.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }

    public bool Creates(List<CompanyParticipant> companyParticipants)
    {
        var transaction = _context.Database.BeginTransaction();

        try
        {
            _context.Set<CompanyParticipant>().AddRange(companyParticipants);
            _context.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }
}

