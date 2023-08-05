using Client.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Client.DTOs.Employees
{
    public class GetEmployeeDto
    {
        [Required]
        public Guid Guid { get; set; }

        [Required]
        public string Nik { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public GenderEnum Gender { get; set; }

        [Required]
        public DateTime HiringDate { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [Phone]
        public Guid CompanyGuid { get; set; }

        [Required]
        public Guid AccountGuid { get; set; }
    }
}
