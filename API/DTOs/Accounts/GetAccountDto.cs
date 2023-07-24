using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Accounts
{
    public class GetAccountDto
    {
        public Guid Guid { get; set; }

        [Required]
        public string Email { get; set; }
        public string? Password { get; set; }

        [Required]
        public bool IsActive { get; set; }
        public int? Token { get; set; }
        public bool? TokenIsUsed { get; set; }
        public DateTime? TokenExpiration { get; set; }
    }
}
