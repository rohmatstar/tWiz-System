using System.ComponentModel.DataAnnotations;

namespace API.DTOs.EventPayments;

public class GetCompanyParticipantsPaidEventDto
{
    [Required]
    public Guid ParticipantGuid { get; set; }

    public string? EventName { get; set; }

    [Required]
    public Guid CompanyGuid { get; set; }

    public string CompanyName { get; set; }

    public string InvitationStatus { get; set; }

    public bool IsPresent { get; set; }

    public Guid EventPayment { get; set; }
    public string PaymentImageUrl { get; set; }
}

