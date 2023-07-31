using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Accounts;

public class CreatedAccountDto
{
    public Guid Guid { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public bool IsActive { get; set; }
}

