using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Companies;

public class ImportEmployeesDto
{
    [Required]
    public Guid CompanyGuid { get; set; }

    [Required]
    public IFormFile Excel { get; set; }

    [Required]
    public string CompanyEmail { get; set; }
}

