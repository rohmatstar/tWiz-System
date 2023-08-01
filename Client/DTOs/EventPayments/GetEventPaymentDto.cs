using Client.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Client.DTOs.EventPayments;

public class GetEventPaymentDto
{
    [Required]
    public Guid Guid { get; set; }

    [Required]
    public Guid AccountGuid { get; set; }

    [Required]
    public Guid EventGuid { get; set; }

    [Required]
    public int VaNumber { get; set; }

    [Required]
    public string? PaymentImage { get; set; }

    [Required]
    public bool IsValid { get; set; }

    [Required]
    public StatusPayment StatusPayment { get; set; }

    [Required]
    public Guid BankGuid { get; set; }
}
