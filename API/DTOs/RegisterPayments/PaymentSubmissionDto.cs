using System.ComponentModel.DataAnnotations;

namespace API.DTOs.RegisterPayments;

public class PaymentSubmissionDto
{
    [Required]
    public Guid Guid { get; set; }

    [Required]
    public IFormFile PaymentImage { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string CompanyName { get; set; }

}

