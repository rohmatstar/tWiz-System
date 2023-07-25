using System.ComponentModel.DataAnnotations;

namespace API.DTOs.EventDocs
{
    public class CreateEventDocDto
    {
        [Required]
        public Guid EventGuid { get; set; }
        public string? Documentation { get; set; }
    }
}