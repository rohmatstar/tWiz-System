using System.ComponentModel.DataAnnotations;

namespace API.DTOs.RegisterPayments
{
    public class PaymentSummaryDto
    {
        public Guid? Guid { get; set; }
        public int VaNumber { get; set; }
        public decimal Price{ get; set; }
        public string? BankCode { get; set; }
        public string? BankName { get; set; }
    }
}
