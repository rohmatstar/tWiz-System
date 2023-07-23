using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("PMTR_ACCOUNT_ROLES")]
public class AccountRole : BaseEntity
{
    [Column ("account_guid")]
    public Guid AccountGuid { get; set; }
    [Column ("role_guid")]
    public Guid RoleGuid { get; set; }

    // Cardinality

    public Role? Role { get; set; }

    public Account? Account { get; set; }
}
