namespace API.DTOs.Events;

public class UpdateParticipantsEventDto
{
    public Guid EventGuid { get; set; }
    public List<Guid>? CompanyParticipantsGuids { get; set; }
    public List<Guid>? EmployeeParticipantsGuids { get; set; }
}

