namespace API.DTOs.EmployeeParticipants
{
    public class CreateEmployeeParticipantDto
    {
        public Guid EventGuid { get; set; }
        public Guid EmployeeGuid { get; set; }
        public bool IsJoin { get; set; }
        public bool IsPresent { get; set; }
    }
}
