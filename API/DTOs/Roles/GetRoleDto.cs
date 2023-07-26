using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Roles
{
    public class GetRoleDto
    {
        [Required]
        public Guid Guid { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
