using Client.Utilities.Validations;
using System.ComponentModel.DataAnnotations;

namespace Client.DTOs.Companies;

public class EmployeeAccountDto
{
    [Required]
    public string Nik { get; set; }

    [Required]
    public string FullName { get; set; }

    [Required]
    public string BirthDate { get; set; }

    [Required]
    public string Gender { get; set; }

    [Required]
    public string HiringDate { get; set; }

    [Required]
    [Phone]
    public string PhoneNumber { get; set; }



    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [PasswordPolicy]
    public string Password { get; set; }

    [Required]
    public string RoleName { get; set; }


}

