using Client.Utilities.Validations;
using System.ComponentModel.DataAnnotations;

namespace Client.DTOs.Auths
{
    public class SignInDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [PasswordPolicy]
        public string Password { get; set; }
    }
}
