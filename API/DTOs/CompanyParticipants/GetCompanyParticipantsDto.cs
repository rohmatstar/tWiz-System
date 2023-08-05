namespace API.DTOs.CompanyParticipants;

public class GetCompanyParticipantsDto
{
    public Guid EventGuid { get; set; }

    public List<Guid> CompanyParticipantGuids { get; set; }
}

