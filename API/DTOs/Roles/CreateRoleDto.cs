using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Roles
{
    public class CreateRoleDto
    {
        [Required]
        public string Name { get; set; }
    }
}
