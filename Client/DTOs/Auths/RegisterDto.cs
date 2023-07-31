using API.Utilities.Enums;
using API.Utilities.Validations;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Auths
{
    public class RegisterDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [PasswordPolicy]
        /*    [DataType(DataType.Password)]*/
        public string Password { get; set; }
        [Required(ErrorMessage = "Password Not Match")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
