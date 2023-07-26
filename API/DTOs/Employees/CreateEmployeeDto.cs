using API.Utilities.Enums;
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
    public GenderEnum Gender { get; set; }

    [Required]
    public DateTime HiringDate { get; set; }

    [Required]
    [Phone]
    public string PhoneNumber { get; set; }

    [Required]
    public Guid CompanyGuid { get; set; }

    [Required]
    public Guid AccountGuid { get; set; }

}
