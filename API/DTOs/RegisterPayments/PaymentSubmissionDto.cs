namespace API.DTOs.RegisterPayments;

public class PaymentSubmissionDto
{
    public Guid Guid { get; set; }

    public IFormFile PaymentImage { get; set; }

}

