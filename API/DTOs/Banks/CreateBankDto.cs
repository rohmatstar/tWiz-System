using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Banks
{
    public class CreateBankDto
    {
        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
