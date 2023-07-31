using System.ComponentModel.DataAnnotations;

namespace Client.DTOs.RegisterPayments;

public class PaymentSubmissionDto
{
    [Required]
    public Guid Guid { get; set; }

    [Required]
    public IFormFile PaymentImage { get; set; }

    [Required]
    public string CompanyName { get; set; }

}

