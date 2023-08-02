namespace API.DTOs.EventPayments;

public class EventPaymentSubmissionDto
{
    public Guid Guid { get; set; }

    public IFormFile PaymentImageFile { get; set; }

    public string AccountName { get; set; }
}

