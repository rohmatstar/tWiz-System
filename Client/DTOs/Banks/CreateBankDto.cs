using System.ComponentModel.DataAnnotations;

namespace Client.DTOs.Banks;

public class CreateBankDto
{
    [Required]
    public string Code { get; set; }

    [Required]
    public string Name { get; set; }
}

