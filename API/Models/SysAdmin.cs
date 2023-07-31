using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("pmdt_sys_admins")]
public class SysAdmin : BaseEntity
{
    [Column("name", TypeName = "nvarchar(50)")]
    public string Name { get; set; }

    [Column("bank_account_number", TypeName = "nvarchar(30)")]
    public string BankAccountNumber { get; set; }

    [Column("account_guid")]
    public Guid AccountGuid { get; set; }

    // Cardinality
    public Account? Account { get; set; }
}

