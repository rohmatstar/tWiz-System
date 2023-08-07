namespace API.DTOs.EventPayments;

public class EventPaymentSummaryDto
{
    public Guid? Guid { get; set; }
    public int VaNumber { get; set; }
    public decimal Price { get; set; }
    public string? BankCode { get; set; }
    public string? BankName { get; set; }
    public string CompanyName { get; set; }
    public string PaymentStatus { get; set; }
}

