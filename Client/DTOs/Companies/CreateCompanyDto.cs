using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Companies;

public class CreateCompanyDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    [Phone]
    public string PhoneNumber { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public Guid AccountGuid { get; set; }
}
