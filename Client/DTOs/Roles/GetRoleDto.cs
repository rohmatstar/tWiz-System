using System.ComponentModel.DataAnnotations;

namespace Client.DTOs.Roles
{
    public class GetRoleDto
    {
        [Required]
        public Guid Guid { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
