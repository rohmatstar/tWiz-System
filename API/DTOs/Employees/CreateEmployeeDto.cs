using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Employees;

public class CreateEmployeeDto
{
    [Required]
    public string Nik { get; set; }

    [Required]
    public string FullName { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    public string Gender { get; set; }

    [Required]
    public DateTime HiringDate { get; set; }

    [Required]
    [Phone]
    public string PhoneNumber { get; set; }

    public string Email { get; set; }

}
