using API.DTOs.CompanyParticipants;
using API.DTOs.EmployeeParticipants;

namespace API.DTOs.Events;

public class GetParticipantsEventDto
{
    public Guid EventGuid { get; set; }
    public string EventName { get; set; }
    public Guid MakerEventGuid { get; set; }
    public List<GetCompanyParticipantDto> CompanyParticipants { get; set; }

    public List<GetEmployeeParticipantDto> EmployeeParticipants { get; set; }
}

