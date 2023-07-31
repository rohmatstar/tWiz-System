using System.ComponentModel.DataAnnotations;

namespace Client.DTOs.Banks;

public class UpdateBankDto
{
    [Required]
    public Guid Guid { get; set; }

    [Required]
    public string Code { get; set; }

    [Required]
    public string Name { get; set; }
}

