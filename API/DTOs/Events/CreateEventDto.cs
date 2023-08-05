using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Events;

public class CreateEventDto
{
    [Required]
    public string Name { get; set; }
    public IFormFile? ThumbnailFile { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public string Visibility { get; set; }

    [Required]
    public string Payment { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public string Category { get; set; }

    [Required]
    public string PlaceType { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public int Quota { get; set; }

    [Required]
    public string Place { get; set; }

}
