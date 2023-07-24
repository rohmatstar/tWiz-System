using API.Utilities.Enums;

namespace API.DTOs.Events
{
    public class EventsDto
    {
        public string? Name { get; set; }
        public string? Thumbnail { get; set; }
        public string? Description { get; set; }
        public bool? IsPublished { get; set; }
        public bool? IsPaid { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public EventStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? Quota { get; set; }
        public string? Place { get; set; }
        public Guid CreatedBy { get; set; }
    }
}