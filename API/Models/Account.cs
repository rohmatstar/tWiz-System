using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;


[Table("pmdt_accounts")]
public class Account : BaseEntity
{
    [Column ("email", TypeName = "varchar(100)")]
    public string Email { get; set; }

    [Column("password", TypeName = "nvarchar(max)")]
    public string Password { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; }

    [Column("token")]
    public int Token { get; set; }
    [Column ("token_is_used")]
    public bool TokenIsUSed { get; set; }

    [Column ("token_expiration")]
    public DateTime? TokenExpiration { get; set; }

    [Column("expired_time")]
    public DateTime? ExpiredTime { get; set; }


    // Cardinality

    public ICollection<AccountRole>? AccountRoles { get; set; }
    public ICollection<EventPayment>? EventPayments { get; set; }
    public Company? Company { get; set; }
    public Employee? Employee { get; set; }
    public RegisterPayment? RegisterPayment { get; set; }
}
