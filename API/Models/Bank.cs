using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("pmdt_banks")]
public class Bank : BaseEntity
{
    [Column ("code", TypeName = "nvarchar(10)")]
    public string Code { get; set; }

    [Column ("name", TypeName = "nvarchar(20)")]
    public string Name { get; set; }

    // Cardinality
    public ICollection<RegisterPayment>? RegisterPayments { get; set; }

    public ICollection<EventPayment>? EventPayments { get; set;}
}
