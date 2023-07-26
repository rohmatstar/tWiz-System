

namespace Client.DTOs
{
    public class GetMasterEmployeeDtoClient
    {
        public Guid Guid { get; set; }
        public string Nik { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
/*        public GenderEnum Gender { get; set; }*/
        public DateTime HiringDate { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
    }
}
