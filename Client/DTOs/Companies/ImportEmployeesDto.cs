using System.ComponentModel.DataAnnotations;

namespace Client.DTOs.Companies;

public class ImportEmployeesDto
{
    [Required]
    public Guid CompanyGuid { get; set; }

    [Required]
    public IFormFile File { get; set; }

}

