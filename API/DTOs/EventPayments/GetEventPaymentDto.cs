using System.ComponentModel.DataAnnotations;

namespace API.DTOs.EventPayments;

public class GetEventPaymentDto
{
    [Required]
    public Guid Guid { get; set; }

    [Required]
    public Guid AccountGuid { get; set; }

    public string AccountName { get; set; }

    [Required]
    public Guid EventGuid { get; set; }

    public string EventName { get; set; }

    [Required]
    public int VaNumber { get; set; }

    [Required]
    public string? PaymentImage { get; set; }

    [Required]
    public bool IsValid { get; set; }

    [Required]
    public string StatusPayment { get; set; }

    [Required]
    public Guid BankGuid { get; set; }

    public string BankName { get; set; }
}
