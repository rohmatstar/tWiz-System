using API.DTOs.CompanyParticipants;
using API.DTOs.EmployeeParticipants;
using API.DTOs.EventPayments;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Events;

public class GetMasterEventDto
{
    public Guid Guid { get; set; }

    [Required]
    public string Name { get; set; }
    public string? Thumbnail { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public string Visibility { get; set; }

    [Required]
    public string Category { get; set; }

    [Required]
    public string PlaceType { get; set; }

    [Required]
    public string Payment { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public int Quota { get; set; }
    public int Joined { get; set; }

    [Required]
    public string StartDate { get; set; }

    [Required]
    public string EndDate { get; set; }

    [Required]
    public string Organizer { get; set; }

    [Required]
    public string Place { get; set; }

    [Required]
    public string PublicationStatus { get; set; }

    public Guid? PaymentGuid { get; set; }

    public List<CompanyParticipantsDto>? CompanyParticipants { get; set; }
    public List<EmployeeParticipantsDto>? EmployeeParticipants { get; set; }
    public List<GetEventPaymentDto>? EventPayments { get; set; }

}

