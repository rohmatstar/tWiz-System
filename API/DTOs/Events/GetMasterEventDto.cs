using API.DTOs.CompanyParticipants;
using API.DTOs.EmployeeParticipants;
using API.DTOs.EventPayments;
using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Events;

public class GetMasterEventDto
{
    [Required]
    public Guid EventGuid { get; set; }

    [Required]
    public string EventName { get; set; }
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

    [Required]
    public int UsedQuota { get; set; }

    [Required]
    public string Place { get; set; }

    [Required]
    public bool IsActive { get; set; }

    [Required]
    public Guid CreatedBy { get; set; }

    public string? CompanyName { get; set; }

    public List<CompanyParticipantsDto>? CompanyParticipants { get; set; }
    public List<EmployeeParticipantsDto>? EmployeeParticipants { get; set; }
    public List<GetEventPaymentDto>? EventPayments { get; set; }

}

