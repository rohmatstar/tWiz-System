namespace API.DTOs.EventDocs
{
    public class EventDocsDto
    {
        public Guid Guid { get; set; }
        public Guid EventGuid { get; set; }
        public string? Documentation { get; set; }
    }
}