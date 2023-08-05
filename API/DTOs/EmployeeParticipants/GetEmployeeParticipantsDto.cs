namespace API.DTOs.EmployeeParticipants;

public class GetEmployeeParticipantsDto
{
    public Guid EventGuid { get; set; }

    public List<Guid> EmployeeParticipantGuids { get; set; }
}

