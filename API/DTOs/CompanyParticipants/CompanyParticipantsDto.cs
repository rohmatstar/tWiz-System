namespace API.DTOs.CompanyParticipants
{
    public class CompanyParticipantsDto
    {
        public Guid Guid { get; set; }
        public Guid EventGuid { get; set; }
        public Guid CompanyGuid { get; set; }
        public bool IsJoin { get; set; }
        public bool IsPresent { get; set; }
    }
}
