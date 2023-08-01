using Client.Utilities.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Client.DTOs.EventPayments;

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

    [DefaultValue(StatusPayment.Pending)]
    public StatusPayment StatusPayment { get; set; }

    [Required]
    public Guid BankGuid { get; set; }

}
