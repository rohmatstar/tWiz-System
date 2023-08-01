using Client.Utilities.Validations;
using System.ComponentModel.DataAnnotations;

namespace Client.DTOs.Accounts
{
    public class CreateAccountDto
    {
        [Required]
        [EmailAddress]
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
