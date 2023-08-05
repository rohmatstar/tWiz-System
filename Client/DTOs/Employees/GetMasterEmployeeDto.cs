namespace Client.DTOs.Employees
{
    public class GetMasterEmployeeDto
    {
        public Guid Guid { get; set; }
        public string Nik { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string HiringDate { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
    }
}
