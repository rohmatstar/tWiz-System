namespace API.DTOs.EventPayments;

public class EventPaymentSubmission
{
    public Guid Guid { get; set; }

    public IFormFile PaymentImageFile { get; set; }
}

