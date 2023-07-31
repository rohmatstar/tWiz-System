using API.Utilities.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.RegisterPayments;

public class CreateRegisterPaymentDto
{
    [Required]
    public Guid CompanyGuid { get; set; }

    [Required]
    public int VaNumber { get; set; }

    [Required]
    public decimal Price { get; set; }
    public string? PaymentImage { get; set; }

    [DefaultValue(false)]
    public bool IsValid { get; set; }

    [DefaultValue(StatusPayment.Pending)]
    public StatusPayment StatusPayment { get; set; }

    [Required]
    public Guid BankGuid { get; set; }
}
