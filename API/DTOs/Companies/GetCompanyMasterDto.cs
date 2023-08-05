using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Companies;

public class GetCompanyMasterDto
{
    [Required]
    public Guid Guid { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [Phone]
    public string PhoneNumber { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public Guid AccountGuid { get; set; }
}
