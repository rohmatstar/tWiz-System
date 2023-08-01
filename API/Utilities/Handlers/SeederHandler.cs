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
                Password = HashingHandler.HashPassword("!Company123"),
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
                Password = HashingHandler.HashPassword("!Company123"),
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
                Password = HashingHandler.HashPassword("!Employee123"),
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
                Password = HashingHandler.HashPassword("!Employee123"),
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
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            _context.Set<Account>().AddRange(new List<Account> { account1, account2, account3, account4, account5 });
            _context.SaveChanges();


            var companyRole = new Role
            {
                Guid = new Guid(),
                Name = nameof(RoleLevel.Company),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeRole = new Role
            {
                Guid = new Guid(),
                Name = nameof(RoleLevel.Employee),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            _context.Set<Role>().AddRange(new List<Role> { companyRole, employeeRole });
            _context.SaveChanges();


            var account1Role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account1.Guid,
                RoleGuid = companyRole.Guid,
            };

            var account2Role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account2.Guid,
                RoleGuid = companyRole.Guid,
            };

            var account3Role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account3.Guid,
                RoleGuid = employeeRole.Guid,
            };

            var account4Role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account4.Guid,
                RoleGuid = employeeRole.Guid,
            };

            var account5Role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account5.Guid,
                RoleGuid = employeeRole.Guid,
            };


            _context.Set<AccountRole>().AddRange(new List<AccountRole> { account1Role, account2Role, account3Role, account4Role, account5Role });
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
                Status = EventStatus.Online,
                IsPublished = true,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event3 = new Event
            {
                Guid = new Guid(),
                Name = "Workshop Create Branding",
                Quota = 50,
                UsedQuota = 10,
                StartDate = new DateTime(2023, 8, 15, 8, 30, 0),
                EndDate = new DateTime(2023, 8, 15, 12, 0, 0),
                Description = "Acara seminar cara membuat branding yang bagus",
                Category = "Brand",
                CreatedBy = company2.Guid,
                IsPaid = true,
                Price = 5000,
                IsActive = true,
                Status = EventStatus.Offline,
                IsPublished = true,
                Place = "jl. pramuka keren",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event4 = new Event
            {
                Guid = new Guid(),
                Name = "Interview PT. JKI",
                Quota = 5,
                UsedQuota = 1,
                StartDate = new DateTime(2023, 8, 15, 8, 30, 0),
                EndDate = new DateTime(2023, 8, 15, 12, 0, 0),
                Description = "Interview Kerja",
                Category = "Interview",
                CreatedBy = company2.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = false,
                Status = EventStatus.Offline,
                IsPublished = false,
                Place = "jl. pramuka keren 3",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var event5 = new Event
            {
                Guid = new Guid(),
                Name = "Interview PT. KLM",
                Quota = 5,
                UsedQuota = 1,
                StartDate = new DateTime(2023, 8, 15, 8, 30, 0),
                EndDate = new DateTime(2023, 8, 15, 12, 0, 0),
                Description = "Interview Kerja",
                Category = "Interview",
                CreatedBy = company2.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Offline,
                IsPublished = false,
                Place = "jl. pramuka keren 2",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event6 = new Event
            {
                Guid = new Guid(),
                Name = "Interview",
                Quota = 3,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 10, 15, 8, 30, 0),
                EndDate = new DateTime(2023, 10, 15, 12, 0, 0),
                Description = "Interview client",
                Category = "Interview",
                CreatedBy = company1.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = false,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            _context.Set<Event>().AddRange(new List<Event> { event1, event2, event3, event4, event5, event6 });
            _context.SaveChanges();

            var companyParticipant_1_1 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event1.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_2_1 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event2.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_3_1 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event3.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_4_1 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event4.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_5_1 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event5.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_6_1 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event6.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            _context.Set<CompanyParticipant>().AddRange(new List<CompanyParticipant> { companyParticipant_1_1, companyParticipant_2_1, companyParticipant_3_1, companyParticipant_4_1, companyParticipant_5_1, companyParticipant_6_1 });
            _context.SaveChanges();

            var employeeParticipant_1_1 = new EmployeeParticipant
            {
                Guid = new Guid(),
                EventGuid = event1.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_1_2 = new EmployeeParticipant
            {
                Guid = new Guid(),
                EventGuid = event1.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_2_1 = new EmployeeParticipant
            {
                Guid = new Guid(),
                EventGuid = event2.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_2_2 = new EmployeeParticipant
            {
                Guid = new Guid(),
                EventGuid = event2.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_3_1 = new EmployeeParticipant
            {
                Guid = new Guid(),
                EventGuid = event3.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            _context.Set<EmployeeParticipant>().AddRange(new List<EmployeeParticipant> { employeeParticipant_1_1, employeeParticipant_1_2, employeeParticipant_2_1, employeeParticipant_2_2, employeeParticipant_3_1 });

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
        using var transaction = _context.Database.BeginTransaction();
        try
        {
            var eventParticipants = _context.Set<EmployeeParticipant>().Where(ep => ep.Guid != new Guid());
            _context.Set<EmployeeParticipant>().RemoveRange(eventParticipants);
            _context.SaveChanges();

            var companyParticipants = _context.Set<CompanyParticipant>().Where(ep => ep.Guid != new Guid());
            _context.Set<CompanyParticipant>().RemoveRange(companyParticipants);
            _context.SaveChanges();

            var events = _context.Set<Event>().Where(a => a.Name != "tidak ada");
            _context.Set<Event>().RemoveRange(events);
            _context.SaveChanges();

            var employees = _context.Set<Employee>().Where(a => a.FullName != "tidak ada");
            _context.Set<Employee>().RemoveRange(employees);
            _context.SaveChanges();


            var companies = _context.Set<Company>().Where(a => a.Name != "tidak ada");
            _context.Set<Company>().RemoveRange(companies);
            _context.SaveChanges();

            var accountRoles = _context.Set<AccountRole>().Where(a => a.Guid != new Guid());
            _context.Set<AccountRole>().RemoveRange(accountRoles);
            _context.SaveChanges();

            var accounts = _context.Set<Account>().Where(a => a.Email != "tidak ada");
            _context.Set<Account>().RemoveRange(accounts);
            _context.SaveChanges();

            var roles = _context.Set<Role>().Where(a => a.Name != "tidak ada");
            _context.Set<Role>().RemoveRange(roles);
            _context.SaveChanges();

            var banks = _context.Set<Bank>().Where(a => a.Name != "tidak ada");
            _context.Set<Bank>().RemoveRange(banks);
            _context.SaveChanges();

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
        }

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

    public void GenerateBanks()
    {
        using var transaction = _context.Database.BeginTransaction();

        try
        {
            var bri = new Bank
            {
                Guid = new Guid(),
                Code = "BRI",
                Name = "Bank Rakyat Indonesia",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };

            var mandiri = new Bank
            {
                Guid = new Guid(),
                Code = "BM",
                Name = "Bank Mandiri",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };

            _context.Set<Bank>().AddRange(new List<Bank> { bri, mandiri });

            _context.SaveChanges();

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
        }

    }
}

