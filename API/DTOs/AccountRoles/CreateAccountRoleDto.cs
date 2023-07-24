using System.ComponentModel.DataAnnotations;

namespace API.DTOs.AccountRoles
{
    public class CreateAccountRoleDto
    {
        [Required]
        public Guid AccountGuid { get; set; }
        [Required]
        public Guid RoleGuid { get; set; }
    }
}
