using System.ComponentModel.DataAnnotations;

namespace Client.Views.EventPayment;

public class GetEmployeeParticipantsPaidEventDto
{
    [Required]
    public Guid ParticipantGuid { get; set; }

    public string EventName { get; set; }

    [Required]
    public Guid EmployeeGuid { get; set; }

    public string EmployeeName { get; set; }
    public string CompanyName { get; set; }

    public string InvitationStatus { get; set; }

    public bool IsPresent { get; set; }

    public Guid? EventPaymentGuid { get; set; }
    public string? PaymentImageUrl { get; set; }
}

