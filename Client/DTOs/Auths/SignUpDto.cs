using Client.Utilities.Validations;
using System.ComponentModel.DataAnnotations;

namespace Client.DTOs.Auths
{
    public class SignUpDto
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
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        /*[DataType(DataType.Password)]*/
        [Compare("Password", ErrorMessage = "Password Not Match")]
        public string ConfirmPassword { get; set; }
    }
}
