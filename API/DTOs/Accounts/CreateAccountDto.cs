using API.Utilities.Validations;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Accounts
{
    public class CreateAccountDto
    {
        [Required]
        [EmailAddress]
        [EmailDuplicateProperty("Guid", "Email")]
        public string Email { get; set; }

        [Required]
        [PasswordPolicy]
        public string Password { get; set; }

        [Required]
        public bool IsActive { get; set; }
        public int? Token { get; set; }
        public bool? TokenIsUsed { get; set; }
        public DateTime? TokenExpiration { get; set; }
    }
}
