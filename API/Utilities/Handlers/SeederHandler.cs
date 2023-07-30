using API.Data;
using API.Models;
using API.Utilities.Enums;

namespace API.Utilities.Handlers;

public class SeederHandler
{
    private readonly TwizDbContext _context;
    public SeederHandler(TwizDbContext context)
    {
        _context = context;
    }

    public void GenerateEventMaster()
    {
        using var transaction = _context.Database.BeginTransaction();
        try
        {
            var account1 = new Account
            {
                Guid = new Guid(),
                Email = "febrianto.bekasi@gmail.com",
                Password = "!Company123",
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var account2 = new Account
            {
                Guid = new Guid(),
                Email = "optimusprime200039@gmail.com",
                Password = "!Company123",
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var account3 = new Account
            {
                Guid = new Guid(),
                Email = "ikxe496@gmail.com",
                Password = "!Employee123",
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var account4 = new Account
            {
                Guid = new Guid(),
                Email = "andri@example.com",
                Password = "!Employee123",
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var account5 = new Account
            {
                Guid = new Guid(),
                Email = "septia@example.com",
                Password = "!Employee123",
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            _context.Set<Account>().AddRange(new List<Account> { account1, account2, account3, account4, account5 });
            _context.SaveChanges();


            var company1 = new Company
            {
                Guid = new Guid(),
                Name = "PT. ABC",
                Address = "Jl. ABC",
                PhoneNumber = "34567111",
                AccountGuid = account1.Guid,
                BankAccountNumber = "3333999227872",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var company2 = new Company
            {
                Guid = new Guid(),
                Name = "PT. XYZ",
                Address = "Jl. XYZ",
                PhoneNumber = "4533111",
                AccountGuid = account2.Guid,
                BankAccountNumber = "333391127872",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            _context.Set<Company>().AddRange(new List<Company> { company1, company2 });
            _context.SaveChanges();



            var employee1 = new Employee
            {
                FullName = "Jasman mosabasa",
                Nik = "1111",
                BirthDate = new DateTime(2000, 02, 12),
                HiringDate = new DateTime(2023, 03, 22),
                Gender = GenderEnum.Male,
                PhoneNumber = "12312312",
                AccountGuid = account3.Guid,
                CompanyGuid = company1.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employee2 = new Employee
            {
                FullName = "Oka Rahul",
                Nik = "22222",
                BirthDate = new DateTime(2000, 04, 11),
                HiringDate = new DateTime(2023, 02, 2),
                Gender = GenderEnum.Male,
                PhoneNumber = "1232232",
                AccountGuid = account4.Guid,
                CompanyGuid = company1.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employee3 = new Employee
            {
                FullName = "Isnaini Rofiah",
                Nik = "33333",
                BirthDate = new DateTime(2000, 05, 12),
                HiringDate = new DateTime(2023, 02, 20),
                Gender = GenderEnum.Female,
                PhoneNumber = "1222332",
                AccountGuid = account5.Guid,
                CompanyGuid = company2.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            _context.Set<Employee>().AddRange(new List<Employee> { employee1, employee2, employee3 });
            _context.SaveChanges();


            var event1 = new Event
            {
                Guid = new Guid(),
                Name = "Seminar Cyber Security",
                Quota = 100,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 11, 15, 8, 30, 0),
                EndDate = new DateTime(2023, 11, 15, 12, 0, 0),
                Description = "Acara seminar tentang cyber security",
                Category = "IT",
                CreatedBy = company1.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = false,
                Status = EventStatus.Online,
                IsPublished = true,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event2 = new Event
            {
                Guid = new Guid(),
                Name = "Seminar Kemerdekaan",
                Quota = 100,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 10, 15, 8, 30, 0),
                EndDate = new DateTime(2023, 10, 15, 12, 0, 0),
                Description = "Acara seminar tentang kemerdekaan RI",
                Category = "Nasional",
                CreatedBy = company1.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Offline,
                IsPublished = true,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            _context.Set<Event>().AddRange(new List<Event> { event1, event2 });
            _context.SaveChanges();

            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            //throw new Exception(ex.Message);
        }


    }


    public void RemoveAllData()
    {
        var accounts = _context.Set<Account>().Where(a => a.Email != "tidak ada");
        _context.Set<Account>().RemoveRange(accounts);
        _context.SaveChanges();


        var companies = _context.Set<Company>().Where(a => a.Name != "tidak ada");
        _context.Set<Company>().RemoveRange(companies);
        _context.SaveChanges();

        var employees = _context.Set<Employee>().Where(a => a.FullName != "tidak ada");
        _context.Set<Employee>().RemoveRange(employees);
        _context.SaveChanges();
    }


    public string GenerateNik()
    {
        // Inisialisasi objek Random
        Random random = new Random();

        // Membuat array karakter yang berisi angka 0 hingga 9
        char[] digits = "0123456789".ToCharArray();

        // Membuat array untuk menyimpan karakter acak
        char[] randomChars = new char[10];

        // Mengisi array dengan karakter acak dari angka 0 hingga 9
        for (int i = 0; i < 10; i++)
        {
            randomChars[i] = digits[random.Next(digits.Length)];
        }

        // Mengonversi array karakter menjadi string
        string randomString = new string(randomChars);

        return randomString;
    }
}

