using API.Models;

namespace API.Contracts;

public interface ICompanyParticipantRepository : IGeneralRepository<CompanyParticipant>
{
    public bool Deletes(List<CompanyParticipant> companyParticipants);
    public bool Creates(List<CompanyParticipant> companyParticipants);

}
