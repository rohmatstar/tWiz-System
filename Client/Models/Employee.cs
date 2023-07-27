using Client.Utilities.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Models
{
    public class Employee
    {
        public string Nik { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime HiringDate { get; set; }
        public string PhoneNumber { get; set; }
        public Guid CompanyGuid { get; set; }
        public Guid AccountGuid { get; set; }
    }
}
