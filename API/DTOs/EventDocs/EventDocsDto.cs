using System.ComponentModel.DataAnnotations;

namespace API.DTOs.EventDocs
{
    public class EventDocsDto
    {
        [Required]
        public Guid Guid { get; set; }

        [Required]
        public Guid EventGuid { get; set; }
        public string? Documentation { get; set; }
    }
}