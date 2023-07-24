namespace API.DTOs.RegisterPayments;

public class CreateRegisterPaymentDto
{
    public Guid CompanyGuid { get; set; }
    public int VaNumber { get; set; }
    public decimal Price { get; set; }
    public string PaymentImage { get; set; }
    public bool IsValid { get; set; }
    public Guid BankGuid { get; set; }
}
