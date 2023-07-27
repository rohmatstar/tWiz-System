using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Models
{
    public class Account
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int? Token { get; set; }
        public bool? TokenIsUsed { get; set; }
        public DateTime? TokenExpiration { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
