using System.ComponentModel.DataAnnotations;

namespace Client.DTOs.AccountRoles
{
    public class UpdateAccountRoleDto
    {
        [Required]
        public Guid Guid { get; set; }
        [Required]
        public Guid AccountGuid { get; set; }
        [Required]
        public Guid RoleGuid { get; set; }
    }
}
