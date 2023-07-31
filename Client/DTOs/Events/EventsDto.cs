using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Events
{
    public class EventsDto
    {
        [Required]
        public Guid Guid { get; set; }

        [Required]
        public string Name { get; set; }
        public string? Thumbnail { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool IsPublished { get; set; }

        [Required]
        public bool IsPaid { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public EventStatus Status { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int Quota { get; set; }


        public int? UsedQuota { get; set; }


        public bool? IsActive { get; set; }

        [Required]
        public string Place { get; set; }

        [Required]
        public Guid CreatedBy { get; set; }


        public string? MakerName { get; set; }
    }
}