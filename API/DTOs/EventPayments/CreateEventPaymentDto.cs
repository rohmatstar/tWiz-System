using API.Utilities.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.EventPayments;

public class CreateEventPaymentDto
{
    [Required]
    public Guid AccountGuid { get; set; }

    [Required]
    public Guid EventGuid { get; set; }

    [Required]
    public int VaNumber { get; set; }

    public string? PaymentImage { get; set; }

    [DefaultValue(false)]
    public bool IsValid { get; set; }

    [DefaultValue(StatusPayment.pending)]
    public StatusPayment StatusPayment { get; set; }

    [Required]
    public Guid BankGuid { get; set; }

}
