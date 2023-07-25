using API.Utilities.Validations;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Auths
{
    public class ChangePasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int Token { get; set; }
        [PasswordPolicy]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Password Not Match")]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }
    }
}
