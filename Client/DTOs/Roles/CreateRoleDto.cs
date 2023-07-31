using System.ComponentModel.DataAnnotations;

namespace Client.DTOs.Roles
{
    public class CreateRoleDto
    {
        [Required]
        public string Name { get; set; }
    }
}
