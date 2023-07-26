using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Banks;

public class GetBankDto
{
    [Required]
    public Guid Guid { get; set; }

    [Required]
    public string Code { get; set; }

    [Required]
    public string Name { get; set; }
}

