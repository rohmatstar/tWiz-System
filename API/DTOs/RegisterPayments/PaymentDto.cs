using System.ComponentModel.DataAnnotations;

namespace API.DTOs.RegisterPayments
{
    public class PaymentDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int VaNumber { get; set; }
    }
}
