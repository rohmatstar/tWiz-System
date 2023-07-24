using API.Utilities.Enums;

namespace API.DTOs.Employees
{
    public class GetEmployeeDto
    {
        public Guid Guid { get; set; }
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
