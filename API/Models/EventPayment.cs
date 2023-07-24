using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;


[Table ("pmdt_event_payments")]
public class EventPayment : BaseEntity
{
    [Column ("account_guid")]
    public Guid AccountGuid { get; set; }

    [Column ("event_guid")]
    public Guid EventGuid { get; set; }

    [Column ("va_number")]
    public int VaNumber { get; set; }

    [Column ("payment_image", TypeName = "nvarchar(max)")]
    public string PaymentImage { get; set; }

    [Column("is_valid")]
    public bool IsValid { get; set; }

    [Column("bank_guid")]
    public Guid BankGuid { get; set; }

    [Column("status_payment")]
    public StatusPayment StatusPayment { get; set; }

    // Cardinality

    public Account? Account { get; set; }
    public Event? Event { get; set; }
    public Bank? Bank { get; set; }
}
