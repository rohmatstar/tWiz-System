using Client.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Client.DTOs.RegisterPayments;

public class GetRegisterPaymentDto
{
    [Required]
    public Guid Guid { get; set; }

    public string CompanyName { get; set; }

    public string CompanyEmail { get; set; }

    [Required]
    public int VaNumber { get; set; }

    [Required]
    public decimal Price { get; set; }
    public string? PaymentImage { get; set; }

    [Required]
    public string ValidationStatus { get; set; }

    [Required]
    public string StatusPayment { get; set; }

    public string BankName { get; set; }

}
