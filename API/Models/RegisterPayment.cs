using API.Utilities.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;


[Table("pmdt_register_payments")]
public class RegisterPayment : BaseEntity
{
    [Column("company_guid")]
    public Guid CompanyGuid { get; set; }

    [Column("va_number")]
    public int VaNumber { get; set; }

    [Precision(10, 2)]
    [Column("price")]
    public decimal Price { get; set; }

    [Column("payment_image", TypeName = "nvarchar(max)")]
    public string PaymentImage { get; set; }

    [Column("is_valid")]
    public bool IsValid { get; set; }

    [Column("bank_guid")]
    public Guid BankGuid { get; set; }

/*    [Column("status_payment")]
    public StatusPayment StatusPayment { get; set; }*/

    // Cardinality

    public Company? Company { get; set; }
    public Bank? Bank { get; set; }
}
