using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.RegisterPayments;

public class GetRegisterPaymentDto
{
    [Required]
    public Guid Guid { get; set; }

    [Required]
    public Guid CompanyGuid { get; set; }

    [Required]
    public int VaNumber { get; set; }

    [Required]
    public decimal Price { get; set; }
    public string? PaymentImage { get; set; }

    [Required]
    public bool IsValid { get; set; }

    [Required]
    public StatusPayment StatusPayment { get; set; }

    [Required]
    public Guid BankGuid { get; set; }

}
