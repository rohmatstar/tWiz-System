using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Roles
{
    public class NewRoleDto
    {
        [Required]
        public string Name { get; set; }
    }
}
