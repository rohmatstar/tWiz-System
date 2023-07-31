using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Companies;

public class ImportEmployeesDto
{
    [Required]
    public Guid CompanyGuid { get; set; }

    [Required]
    public IFormFile File { get; set; }

}

