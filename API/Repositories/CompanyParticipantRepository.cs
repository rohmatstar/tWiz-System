using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories
{
    public class CompanyParticipantRepository : GeneralRepository<CompanyParticipant>, ICompanyParticipantRepository
    {
        public CompanyParticipantRepository(TwizDbContext context) : base(context)
        {
        }
    }
}
