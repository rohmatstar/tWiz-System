namespace API.DTOs.EventDocs
{
    public class CreateEventDocDto
    {
        public Guid EventGuid { get; set; }
        public string? Documentation { get; set; }
    }
}