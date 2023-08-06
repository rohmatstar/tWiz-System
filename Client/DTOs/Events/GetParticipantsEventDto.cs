using Client.DTOs.CompanyParticipants;
using Client.DTOs.EmployeeParticipants;

namespace Client.DTOs.Events;

public class GetParticipantsEventDto
{
    public Guid EventGuid { get; set; }
    public List<GetCompanyParticipantDto> CompanyParticipants { get; set; }

    public List<GetEmployeeParticipantDto> EmployeeParticipants { get; set; }
}

