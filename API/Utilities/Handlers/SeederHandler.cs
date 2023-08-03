using API.Data;
using API.Models;
using API.Utilities.Enums;
using DocumentFormat.OpenXml.InkML;
using Microsoft.Extensions.Logging;

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
            var account6 = new Account
            {
                Guid = new Guid(),
                Email = "prawiramanik19@gmail.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            var account7 = new Account
            {
                Guid = new Guid(),
                Email = "rayvaldoprawira@gmail.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            var account8 = new Account
            {
                Guid = new Guid(),
                Email = "kagemonji@example.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            var account9 = new Account
            {
                Guid = new Guid(),
                Email = "sophia@example.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            var account10 = new Account
            {
                Guid = new Guid(),
                Email = "bodat@example.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var account11 = new Account
            {
                Guid = new Guid(),
                Email = "twiz.mcc@gmail.com",
                Password = HashingHandler.HashPassword("!Admin123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var account12 = new Account
            {
                Guid = new Guid(),
                Email = "kagemonji@gmail.com",
                Password = HashingHandler.HashPassword("!Company123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var account13 = new Account
            {
                Guid = new Guid(),
                Email = "saras008@gmail.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var account14 = new Account
            {
                Guid = new Guid(),
                Email = "ojk@gmail.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var account15 = new Account
            {
                Guid = new Guid(),
                Email = "ojk1@gmail.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var account16 = new Account
            {
                Guid = new Guid(),
                Email = "ojk2@gmail.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var account17 = new Account
            {
                Guid = new Guid(),
                Email = "ojk3@gmail.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var account18 = new Account
            {
                Guid = new Guid(),
                Email = "ojk4@gmail.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var account19 = new Account
            {
                Guid = new Guid(),
                Email = "ojk5@gmail.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var account20 = new Account
            {
                Guid = new Guid(),
                Email = "ojk6@gmail.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var account21 = new Account
            {
                Guid = new Guid(),
                Email = "ojk7@gmail.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var account22 = new Account
            {
                Guid = new Guid(),
                Email = "ojk8@gmail.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var account23 = new Account
            {
                Guid = new Guid(),
                Email = "ojk9@gmail.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var account24 = new Account
            {
                Guid = new Guid(),
                Email = "ojk10@gmail.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var account25 = new Account
            {
                Guid = new Guid(),
                Email = "ojk11@gmail.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var account26 = new Account
            {
                Guid = new Guid(),
                Email = "ojk12@gmail.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var account27 = new Account
            {
                Guid = new Guid(),
                Email = "ojk13@gmail.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var account28 = new Account
            {
                Guid = new Guid(),
                Email = "ojk14@gmail.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var account29 = new Account
            {
                Guid = new Guid(),
                Email = "ojk15@gmail.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var account30 = new Account
            {
                Guid = new Guid(),
                Email = "ojk16@gmail.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var account31 = new Account
            {
                Guid = new Guid(),
                Email = "ojk17@gmail.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var account32 = new Account
            {
                Guid = new Guid(),
                Email = "ojk18@gmail.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var account33 = new Account
            {
                Guid = new Guid(),
                Email = "ojk19@gmail.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var account34 = new Account
            {
                Guid = new Guid(),
                Email = "ojk20@gmail.com",
                Password = HashingHandler.HashPassword("!Employee123"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            _context.Set<Account>().AddRange(new List<Account> { account1, account2, account3, account4, account5, account6, account7, account8, account9, account10, account11, account12, account13, account14, account15, account16, account17, account18, account19, account20, account21, account22, account23, account24, account25, account26, account27, account28, account29, account30, account31, account32, account33, account34 });
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

            var sysadminRole = new Role
            {
                Guid = new Guid(),
                Name = nameof(RoleLevel.SysAdmin),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            _context.Set<Role>().AddRange(new List<Role> { companyRole, employeeRole, sysadminRole });
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

            var account6role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account6.Guid,
                RoleGuid = employeeRole.Guid,
            };

            var account7role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account7.Guid,
                RoleGuid = employeeRole.Guid,
            };

            var account8role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account8.Guid,
                RoleGuid = employeeRole.Guid,
            };

            var account9role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account9.Guid,
                RoleGuid = employeeRole.Guid,
            };

            var account10role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account10.Guid,
                RoleGuid = employeeRole.Guid,
            };

            var account11role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account11.Guid,
                RoleGuid = sysadminRole.Guid,
            };

            var account12role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account12.Guid,
                RoleGuid = companyRole.Guid,
            };

            var account13role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account13.Guid,
                RoleGuid = employeeRole.Guid,
            };

            var account14role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account14.Guid,
                RoleGuid = employeeRole.Guid,
            };

            var account15role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account15.Guid,
                RoleGuid = employeeRole.Guid,
            };

            var account16role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account16.Guid,
                RoleGuid = employeeRole.Guid,
            };

            var account17role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account17.Guid,
                RoleGuid = employeeRole.Guid,
            };


            var account18role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account18.Guid,
                RoleGuid = employeeRole.Guid,
            };


            var account19role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account19.Guid,
                RoleGuid = employeeRole.Guid,
            };

            var account20role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account20.Guid,
                RoleGuid = employeeRole.Guid,
            };

            var account21role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account21.Guid,
                RoleGuid = employeeRole.Guid,
            };

            var account22role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account22.Guid,
                RoleGuid = employeeRole.Guid,
            };

            var account23role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account23.Guid,
                RoleGuid = employeeRole.Guid,
            };

            var account24role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account24.Guid,
                RoleGuid = employeeRole.Guid,
            };


            var account25role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account25.Guid,
                RoleGuid = employeeRole.Guid,
            };


            var account26role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account26.Guid,
                RoleGuid = employeeRole.Guid,
            };

            var account27role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account27.Guid,
                RoleGuid = employeeRole.Guid,
            };


            var account28role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account28.Guid,
                RoleGuid = employeeRole.Guid,
            };

            var account29role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account29.Guid,
                RoleGuid = employeeRole.Guid,
            };


            var account30role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account30.Guid,
                RoleGuid = employeeRole.Guid,
            };


            var account31role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account31.Guid,
                RoleGuid = employeeRole.Guid,
            };

            var account32role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account32.Guid,
                RoleGuid = employeeRole.Guid,
            };


            var account33role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account33.Guid,
                RoleGuid = employeeRole.Guid,
            };


            var account34role = new AccountRole
            {
                Guid = new Guid(),
                AccountGuid = account34.Guid,
                RoleGuid = employeeRole.Guid,
            };

            _context.Set<AccountRole>().AddRange(new List<AccountRole> { account1Role, account2Role, account3Role, account4Role, account5Role, account6role, account7role, account8role, account9role, account10role, account11role, account12role, account13role, account14role, account15role, account16role, account17role, account18role, account19role, account20role, account21role, account22role, account23role, account24role, account25role, account26role, account27role, account28role, account29role, account30role, account31role, account32role, account33role, account34role });
            _context.SaveChanges();

            var company1 = new Company
            {
                Guid = new Guid(),
                Name = "PT.ABC",
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
                Name = "PT.XYZ",
                Address = "Jl.XYZ",
                PhoneNumber = "4533111",
                AccountGuid = account2.Guid,
                BankAccountNumber = "333391127872",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var company3 = new Company
            {
                Guid = new Guid(),
                Name = "PT.RAY",
                Address = "JL.Bojong Koneng",
                PhoneNumber = "085555867777",
                AccountGuid = account12.Guid,
                BankAccountNumber = "55555726656",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            _context.Set<Company>().AddRange(new List<Company> { company1, company2, company3 });
            _context.SaveChanges();



            var employee1 = new Employee
            {
                FullName = "Jasman mosabasa",
                Nik = "11101",
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
                Nik = "11102",
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
                Nik = "11103",
                BirthDate = new DateTime(2000, 05, 12),
                HiringDate = new DateTime(2023, 02, 20),
                Gender = GenderEnum.Female,
                PhoneNumber = "1222332",
                AccountGuid = account5.Guid,
                CompanyGuid = company1.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employee4 = new Employee
            {
                FullName = "Sujatmiko Abdulah",
                Nik = "11104",
                BirthDate = new DateTime(1995, 03, 20),
                HiringDate = new DateTime(2021, 06, 19),
                Gender = GenderEnum.Male,
                PhoneNumber = "085772144577",
                AccountGuid = account6.Guid,
                CompanyGuid = company1.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employee5 = new Employee
            {
                FullName = "Raka Budut",
                Nik = "11105",
                BirthDate = new DateTime(1995, 04, 20),
                HiringDate = new DateTime(2021, 05, 19),
                Gender = GenderEnum.Male,
                PhoneNumber = "085772144321",
                AccountGuid = account7.Guid,
                CompanyGuid = company1.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employee6 = new Employee
            {
                FullName = "Leyhan Abil",
                Nik = "11106",
                BirthDate = new DateTime(1995, 05, 20),
                HiringDate = new DateTime(2021, 04, 19),
                Gender = GenderEnum.Male,
                PhoneNumber = "085772143367",
                AccountGuid = account8.Guid,
                CompanyGuid = company1.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employee7 = new Employee
            {
                FullName = "Kiko Kikah",
                Nik = "11107",
                BirthDate = new DateTime(1995, 06, 20),
                HiringDate = new DateTime(2021, 03, 19),
                Gender = GenderEnum.Male,
                PhoneNumber = "085772144544",
                AccountGuid = account9.Guid,
                CompanyGuid = company1.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            var employee8 = new Employee
            {
                FullName = "Sumiati Abdulah",
                Nik = "11108",
                BirthDate = new DateTime(1995, 07, 20),
                HiringDate = new DateTime(2021, 02, 19),
                Gender = GenderEnum.Female,
                PhoneNumber = "085772144123",
                AccountGuid = account10.Guid,
                CompanyGuid = company1.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employee9 = new Employee
            {
                FullName = "Chris Sumanto",
                Nik = "11109",
                BirthDate = new DateTime(1995, 07, 20),
                HiringDate = new DateTime(2021, 02, 19),
                Gender = GenderEnum.Male,
                PhoneNumber = "085772144521",
                AccountGuid = account13.Guid,
                CompanyGuid = company1.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employee10 = new Employee
            {
                FullName = "Dhani Budi",
                Nik = "11110",
                BirthDate = new DateTime(1995, 07, 20),
                HiringDate = new DateTime(2021, 02, 19),
                Gender = GenderEnum.Female,
                PhoneNumber = "08577214213",
                AccountGuid = account14.Guid,
                CompanyGuid = company1.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var employee11 = new Employee
            {
                FullName = "Chirtina Widiarti",
                Nik = "11111",
                BirthDate = new DateTime(2000, 07, 12),
                HiringDate = new DateTime(2021, 02, 18),
                Gender = GenderEnum.Female,
                PhoneNumber = "085772144124",
                AccountGuid = account15.Guid,
                CompanyGuid = company2.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employee12 = new Employee
            {
                FullName = "Yolanda Novit",
                Nik = "11112",
                BirthDate = new DateTime(1999, 11, 20),
                HiringDate = new DateTime(2021, 02, 17),
                Gender = GenderEnum.Female,
                PhoneNumber = "085772144098",
                AccountGuid = account16.Guid,
                CompanyGuid = company2.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employee13 = new Employee
            {
                FullName = "Cindy Calista",
                Nik = "11113",
                BirthDate = new DateTime(2000, 07, 20),
                HiringDate = new DateTime(2021, 10, 07),
                Gender = GenderEnum.Female,
                PhoneNumber = "085772144566",
                AccountGuid = account17.Guid,
                CompanyGuid = company2.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employee14 = new Employee
            {
                FullName = "Bodat Ersetiawan",
                Nik = "11114",
                BirthDate = new DateTime(1995, 05, 19),
                HiringDate = new DateTime(2021, 01, 02),
                Gender = GenderEnum.Male,
                PhoneNumber = "085772144147",
                AccountGuid = account18.Guid,
                CompanyGuid = company2.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employee15 = new Employee
            {
                FullName = "Nessa Vanesha",
                Nik = "11115",
                BirthDate = new DateTime(1995, 04, 17),
                HiringDate = new DateTime(2022, 02, 09),
                Gender = GenderEnum.Female,
                PhoneNumber = "085772144588",
                AccountGuid = account19.Guid,
                CompanyGuid = company2.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employee16 = new Employee
            {
                FullName = "Dita Veronica",
                Nik = "11116",
                BirthDate = new DateTime(1996, 03, 31),
                HiringDate = new DateTime(2021, 05, 10),
                Gender = GenderEnum.Female,
                PhoneNumber = "085772144599",
                AccountGuid = account20.Guid,
                CompanyGuid = company2.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var employee17 = new Employee
            {
                FullName = "Marcelina Marcelino",
                Nik = "11117",
                BirthDate = new DateTime(1995, 01, 30),
                HiringDate = new DateTime(2021, 04, 12),
                Gender = GenderEnum.Female,
                PhoneNumber = "085772144600",
                AccountGuid = account21.Guid,
                CompanyGuid = company2.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employee18 = new Employee
            {
                FullName = "Liam Galaghar",
                Nik = "11118",
                BirthDate = new DateTime(1993, 08, 12),
                HiringDate = new DateTime(2020, 08, 3),
                Gender = GenderEnum.Male,
                PhoneNumber = "085772144601",
                AccountGuid = account22.Guid,
                CompanyGuid = company2.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employee19 = new Employee
            {
                FullName = "Soekarni Putri",
                Nik = "11119",
                BirthDate = new DateTime(1994, 08, 17),
                HiringDate = new DateTime(2021, 07, 19),
                Gender = GenderEnum.Female,
                PhoneNumber = "085772144602",
                AccountGuid = account23.Guid,
                CompanyGuid = company2.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employee20 = new Employee
            {
                FullName = "Math Physics",
                Nik = "11120",
                BirthDate = new DateTime(1995, 07, 20),
                HiringDate = new DateTime(2023, 01, 17),
                Gender = GenderEnum.Male,
                PhoneNumber = "085772144603",
                AccountGuid = account24.Guid,
                CompanyGuid = company2.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employee21 = new Employee
            {
                FullName = "Karina Putri",
                Nik = "11121",
                BirthDate = new DateTime(2000, 07, 08),
                HiringDate = new DateTime(2023, 01, 01),
                Gender = GenderEnum.Female,
                PhoneNumber = "085772144604",
                AccountGuid = account25.Guid,
                CompanyGuid = company3.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employee22 = new Employee
            {
                FullName = "Catherine Marceline",
                Nik = "11122",
                BirthDate = new DateTime(2000, 07, 05),
                HiringDate = new DateTime(2023, 01, 12),
                Gender = GenderEnum.Female,
                PhoneNumber = "085772144605",
                AccountGuid = account26.Guid,
                CompanyGuid = company3.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employee23 = new Employee
            {
                FullName = "Elga Agatha",
                Nik = "11123",
                BirthDate = new DateTime(2000, 12, 20),
                HiringDate = new DateTime(2022, 10, 01),
                Gender = GenderEnum.Female,
                PhoneNumber = "085772144606",
                AccountGuid = account27.Guid,
                CompanyGuid = company3.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employee24 = new Employee
            {
                FullName = "Ray Manik",
                Nik = "11124",
                BirthDate = new DateTime(2000, 05, 19),
                HiringDate = new DateTime(2022, 08, 09),
                Gender = GenderEnum.Male,
                PhoneNumber = "085772144607",
                AccountGuid = account28.Guid,
                CompanyGuid = company3.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employee25 = new Employee
            {
                FullName = "Cesar Juliant",
                Nik = "11125",
                BirthDate = new DateTime(2000, 07, 13),
                HiringDate = new DateTime(2022, 01, 17),
                Gender = GenderEnum.Male,
                PhoneNumber = "085772144608",
                AccountGuid = account29.Guid,
                CompanyGuid = company3.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employee26 = new Employee
            {
                FullName = "Andriligar Putra",
                Nik = "11126",
                BirthDate = new DateTime(2000, 05, 25),
                HiringDate = new DateTime(2022, 05, 17),
                Gender = GenderEnum.Male,
                PhoneNumber = "085772144609",
                AccountGuid = account30.Guid,
                CompanyGuid = company3.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employee27 = new Employee
            {
                FullName = "Kelvin Herdian",
                Nik = "11127",
                BirthDate = new DateTime(1999, 09, 20),
                HiringDate = new DateTime(2018, 04, 15),
                Gender = GenderEnum.Male,
                PhoneNumber = "085772144610",
                AccountGuid = account31.Guid,
                CompanyGuid = company3.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employee28 = new Employee
            {
                FullName = "Bayu Ramadhika",
                Nik = "11128",
                BirthDate = new DateTime(2000, 12, 08),
                HiringDate = new DateTime(2023, 01, 10),
                Gender = GenderEnum.Male,
                PhoneNumber = "085772144611",
                AccountGuid = account32.Guid,
                CompanyGuid = company3.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employee29 = new Employee
            {
                FullName = "Naruto Uzumaki",
                Nik = "11129",
                BirthDate = new DateTime(1995, 06, 10),
                HiringDate = new DateTime(2023, 02, 18),
                Gender = GenderEnum.Male,
                PhoneNumber = "085772144612",
                AccountGuid = account33.Guid,
                CompanyGuid = company3.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employee30 = new Employee
            {
                FullName = "Adib Rayhan",
                Nik = "11130",
                BirthDate = new DateTime(2000, 07, 07),
                HiringDate = new DateTime(2023, 01, 17),
                Gender = GenderEnum.Male,
                PhoneNumber = "085772144613",
                AccountGuid = account34.Guid,
                CompanyGuid = company3.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            _context.Set<Employee>().AddRange(new List<Employee> { employee1, employee2, employee3, employee4, employee5, employee6, employee7, employee8, employee9, employee10, employee11, employee12, employee13, employee14, employee15, employee16, employee17, employee18, employee19, employee20, employee21, employee22, employee23, employee24, employee25, employee26, employee27, employee28, employee29, employee30 });
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
                IsActive = true,
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
                StartDate = new DateTime(2023, 08, 17, 8, 30, 0),
                EndDate = new DateTime(2023, 08, 17, 12, 0, 0),
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
                CreatedBy = company1.Guid,
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
                CreatedBy = company1.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Offline,
                IsPublished = true,
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
                CreatedBy = company1.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Offline,
                IsPublished = true,
                Place = "jl. pramuka keren 2",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event6 = new Event
            {
                Guid = new Guid(),
                Name = "WorkShop Big Data",
                Quota = 10,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 10, 15, 8, 30, 0),
                EndDate = new DateTime(2023, 10, 18, 12, 0, 0),
                Description = "Workshop Dengan Tema yang diusung berupa Big Data Dengan Implementasi praktek secara langsung",
                Category = "Workshop",
                CreatedBy = company1.Guid,
                IsPaid = true,
                Price = 150000,
                IsActive = true,
                Status = EventStatus.Offline,
                IsPublished = true,
                Place = "PT.ABC",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var event7 = new Event
            {
                Guid = new Guid(),
                Name = "Webinar Cyber Security",
                Quota = 100,
                UsedQuota = 10,
                StartDate = new DateTime(2023, 11, 10, 12, 0, 0),
                EndDate = new DateTime(2023, 11, 10, 15, 0, 0),
                Description = "Webinar Cyber Security Dengan Narasumber xyz",
                Category = "Webinar",
                CreatedBy = company1.Guid,
                IsPaid = true,
                Price = 75000,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = true,
                Place = "Microsoft Teams",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event8 = new Event
            {
                Guid = new Guid(),
                Name = "Recruitment Developer IT",
                Quota = 3,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 07, 07, 8, 30, 0),
                EndDate = new DateTime(2023, 07, 08, 17, 0, 0),
                Description = "Recruitment Karyawan PT.ABC Untuk Bagian Developer IT",
                Category = "Interview",
                CreatedBy = company1.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Offline,
                IsPublished = true,
                Place = "PT.ABC",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event9 = new Event
            {
                Guid = new Guid(),
                Name = "Webinar Management Ekonomi",
                Quota = 50,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 09, 10, 8, 30, 0),
                EndDate = new DateTime(2023, 09, 10, 12, 0, 0),
                Description = "Webinar Management Ekonomi bagaimana cara untuk mengatur keuangan menjadi lebih baik",
                Category = "Webinar",
                CreatedBy = company1.Guid,
                IsPaid = true,
                Price = 50000,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = true,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event10 = new Event
            {
                Guid = new Guid(),
                Name = "Webinar Digital Marketing",
                Quota = 100,
                UsedQuota = 10,
                StartDate = new DateTime(2023, 05, 12, 8, 30, 0),
                EndDate = new DateTime(2023, 05, 12, 15, 0, 0),
                Description = "Webinar Digital Marketing",
                Category = "Webinar",
                CreatedBy = company1.Guid,
                IsPaid = true,
                Price = 100000,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = true,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event11 = new Event
            {
                Guid = new Guid(),
                Name = "Seminar Cyber Security JILID 2 PT.XYZ",
                Quota = 100,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 11, 15, 8, 30, 0),
                EndDate = new DateTime(2023, 11, 15, 12, 0, 0),
                Description = "Acara seminar tentang cyber security",
                Category = "IT",
                CreatedBy = company2.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = true,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event12 = new Event
            {
                Guid = new Guid(),
                Name = "Seminar Kemerdekaan PT.XYZ",
                Quota = 100,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 08, 17, 8, 30, 0),
                EndDate = new DateTime(2023, 08, 17, 12, 0, 0),
                Description = "Acara seminar tentang kemerdekaan RI",
                Category = "Nasional",
                CreatedBy = company2.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = true,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event13 = new Event
            {
                Guid = new Guid(),
                Name = "Workshop Create Branding JILID 2 PT.XYZ",
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
                Place = "PT.XYZ",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event14 = new Event
            {
                Guid = new Guid(),
                Name = "Interview PT.ZXC",
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
                IsPublished = true,
                Place = "jl. Bojong Koneng",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var event15 = new Event
            {
                Guid = new Guid(),
                Name = "Interview PT. VBN",
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
                IsPublished = true,
                Place = "JL.Bojong Nangka",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event16 = new Event
            {
                Guid = new Guid(),
                Name = "WorkShop Big Data JILID 2 PT.XYZ",
                Quota = 10,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 10, 15, 8, 30, 0),
                EndDate = new DateTime(2023, 10, 18, 12, 0, 0),
                Description = "Workshop Dengan Tema yang diusung berupa Big Data Dengan Implementasi praktek secara langsung",
                Category = "Workshop",
                CreatedBy = company2.Guid,
                IsPaid = true,
                Price = 150000,
                IsActive = true,
                Status = EventStatus.Offline,
                IsPublished = true,
                Place = "PT.XYZ",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var event17 = new Event
            {
                Guid = new Guid(),
                Name = "Webinar Cyber Security JILID 2 PT.XYZ",
                Quota = 100,
                UsedQuota = 10,
                StartDate = new DateTime(2023, 11, 10, 12, 0, 0),
                EndDate = new DateTime(2023, 11, 10, 15, 0, 0),
                Description = "Webinar Cyber Security Dengan Narasumber iop",
                Category = "Webinar",
                CreatedBy = company2.Guid,
                IsPaid = true,
                Price = 75000,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = true,
                Place = "Microsoft Teams",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event18 = new Event
            {
                Guid = new Guid(),
                Name = "Recruitment Developer IT PT.XYZ",
                Quota = 3,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 07, 07, 8, 30, 0),
                EndDate = new DateTime(2023, 07, 08, 17, 0, 0),
                Description = "Recruitment Karyawan PT.XYZ Untuk Bagian Developer IT",
                Category = "Interview",
                CreatedBy = company2.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Offline,
                IsPublished = true,
                Place = "PT.XYZ",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event19 = new Event
            {
                Guid = new Guid(),
                Name = "Webinar Management Ekonomi PT.XYZ",
                Quota = 50,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 09, 10, 8, 30, 0),
                EndDate = new DateTime(2023, 09, 10, 12, 0, 0),
                Description = "Webinar Management Ekonomi bagaimana cara untuk mengatur keuangan menjadi lebih baik",
                Category = "Webinar",
                CreatedBy = company2.Guid,
                IsPaid = true,
                Price = 50000,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = true,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event20 = new Event
            {
                Guid = new Guid(),
                Name = "Webinar Digital Marketing PT.XYZ",
                Quota = 100,
                UsedQuota = 10,
                StartDate = new DateTime(2023, 05, 12, 8, 30, 0),
                EndDate = new DateTime(2023, 05, 12, 15, 0, 0),
                Description = "Webinar Digital Marketing",
                Category = "Webinar",
                CreatedBy = company2.Guid,
                IsPaid = true,
                Price = 100000,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = true,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event21 = new Event
            {
                Guid = new Guid(),
                Name = "Seminar Cyber Security PT.RAY",
                Quota = 100,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 11, 15, 8, 30, 0),
                EndDate = new DateTime(2023, 11, 15, 12, 0, 0),
                Description = "Acara seminar tentang cyber security",
                Category = "IT",
                CreatedBy = company3.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = true,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event22 = new Event
            {
                Guid = new Guid(),
                Name = "Seminar Kemerdekaan PT.RAY",
                Quota = 100,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 08, 17, 8, 30, 0),
                EndDate = new DateTime(2023, 08, 17, 12, 0, 0),
                Description = "Acara seminar tentang kemerdekaan RI",
                Category = "Nasional",
                CreatedBy = company3.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = true,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event23 = new Event
            {
                Guid = new Guid(),
                Name = "Workshop Create Branding PT.RAY",
                Quota = 50,
                UsedQuota = 10,
                StartDate = new DateTime(2023, 8, 15, 8, 30, 0),
                EndDate = new DateTime(2023, 8, 15, 12, 0, 0),
                Description = "Acara seminar cara membuat branding yang bagus",
                Category = "Brand",
                CreatedBy = company3.Guid,
                IsPaid = true,
                Price = 5000,
                IsActive = true,
                Status = EventStatus.Offline,
                IsPublished = true,
                Place = "PT.RAY",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event24 = new Event
            {
                Guid = new Guid(),
                Name = "Interview PT.RTY",
                Quota = 5,
                UsedQuota = 1,
                StartDate = new DateTime(2023, 8, 15, 8, 30, 0),
                EndDate = new DateTime(2023, 8, 15, 12, 0, 0),
                Description = "Interview Kerja",
                Category = "Interview",
                CreatedBy = company3.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Offline,
                IsPublished = true,
                Place = "jl.Bojong Kulur",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var event25 = new Event
            {
                Guid = new Guid(),
                Name = "Interview PT.QWE",
                Quota = 5,
                UsedQuota = 1,
                StartDate = new DateTime(2023, 8, 15, 8, 30, 0),
                EndDate = new DateTime(2023, 8, 15, 12, 0, 0),
                Description = "Interview Kerja",
                Category = "Interview",
                CreatedBy = company3.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Offline,
                IsPublished = true,
                Place = "JL.Tanjung Duren",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event26 = new Event
            {
                Guid = new Guid(),
                Name = "WorkShop Big Data PT.RAY",
                Quota = 10,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 10, 15, 8, 30, 0),
                EndDate = new DateTime(2023, 10, 18, 12, 0, 0),
                Description = "Workshop Dengan Tema yang diusung berupa Big Data Dengan Implementasi praktek secara langsung",
                Category = "Workshop",
                CreatedBy = company3.Guid,
                IsPaid = true,
                Price = 150000,
                IsActive = true,
                Status = EventStatus.Offline,
                IsPublished = true,
                Place = "PT.RAY",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var event27 = new Event
            {
                Guid = new Guid(),
                Name = "Webinar Cyber Security PT.RAY",
                Quota = 100,
                UsedQuota = 10,
                StartDate = new DateTime(2023, 11, 10, 12, 0, 0),
                EndDate = new DateTime(2023, 11, 10, 15, 0, 0),
                Description = "Webinar Cyber Security Dengan Narasumber xyz",
                Category = "Webinar",
                CreatedBy = company3.Guid,
                IsPaid = true,
                Price = 75000,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = true,
                Place = "Microsoft Teams",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event28 = new Event
            {
                Guid = new Guid(),
                Name = "Recruitment Developer IT PT.RAY",
                Quota = 3,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 07, 07, 8, 30, 0),
                EndDate = new DateTime(2023, 07, 08, 17, 0, 0),
                Description = "Recruitment Karyawan PT.ABC Untuk Bagian Developer IT",
                Category = "Interview",
                CreatedBy = company3.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Offline,
                IsPublished = true,
                Place = "PT.ABC",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event29 = new Event
            {
                Guid = new Guid(),
                Name = "Webinar Management Ekonomi PT.RAY",
                Quota = 50,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 09, 10, 8, 30, 0),
                EndDate = new DateTime(2023, 09, 10, 12, 0, 0),
                Description = "Webinar Management Ekonomi bagaimana cara untuk mengatur keuangan menjadi lebih baik",
                Category = "Webinar",
                CreatedBy = company3.Guid,
                IsPaid = true,
                Price = 50000,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = true,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event30 = new Event
            {
                Guid = new Guid(),
                Name = "Webinar Digital Marketing PT.RAY",
                Quota = 100,
                UsedQuota = 10,
                StartDate = new DateTime(2023, 05, 12, 8, 30, 0),
                EndDate = new DateTime(2023, 05, 12, 15, 0, 0),
                Description = "Webinar Digital Marketing",
                Category = "Webinar",
                CreatedBy = company3.Guid,
                IsPaid = true,
                Price = 100000,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = true,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            _context.Set<Event>().AddRange(new List<Event> { event1, event2, event3, event4, event5, event6, event7, event8, event9, event10, event11, event12, event13, event14, event15, event16, event17, event18, event19, event20, event21, event22, event23, event24, event25, event26, event27, event28, event29, event30 });
            _context.SaveChanges();


            var companyParticipant_3_c1_1 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event3.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_3_c2_2 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event3.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_3_c3_3 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event3.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_6_c1_4 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event6.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_6_c2_5 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event6.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_6_c3_6 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event6.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_7_c1_7 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event7.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_7_c2_8 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event7.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_7_c3_9 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event7.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_9_c1_10 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event9.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_9_c2_11 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event9.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_9_c3_12 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event9.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_10_c1_13 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event10.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_10_c2_14 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event10.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_10_c3_15 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event10.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_13_c1_16 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event13.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_13_c2_17 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event13.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_13_c3_18 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event13.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_16_c1_19 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event16.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_16_c2_20 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event16.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_16_c3_21 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event16.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_17_c1_22 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event17.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_17_c2_23 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event17.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_17_c3_24 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event17.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var companyParticipant_19_c1_25 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event19.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_19_c2_26 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event19.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_19_c3_27 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event19.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_20_c1_28 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event20.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_20_c2_29 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event20.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_20_c3_30 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event20.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_23_c1_31 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event23.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_23_c2_32 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event23.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_23_c3_33 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event23.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_26_c1_34 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event26.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_26_c2_35 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event26.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_26_c3_36 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event26.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_27_c1_37 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event27.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_27_c2_38 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event27.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_27_c3_39 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event27.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_29_c1_40 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event29.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_29_c2_41 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event29.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var companyParticipant_29_c3_42 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event29.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_30_c1_43 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event30.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_30_c2_44 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event30.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var companyParticipant_30_c3_45 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event30.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_1_c1_46 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event1.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_1_c2_47 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event1.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var companyParticipant_1_c3_48 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event1.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_2_c1_49 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event2.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_2_c2_50 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event2.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var companyParticipant_2_c3_51 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event2.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_4_c1_52 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event30.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_4_c2_53 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event4.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var companyParticipant_4_c3_54 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event4.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_5_c1_55 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event5.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_5_c2_56 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event5.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var companyParticipant_5_c3_57 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event5.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_8_c1_58 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event8.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_8_c2_59 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event8.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var companyParticipant_8_c3_60 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event8.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_11_c1_61 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event11.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_11_c2_62 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event11.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var companyParticipant_11_c3_63 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event11.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var companyParticipant_12_c1_64 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event12.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_12_c2_65 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event12.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var companyParticipant_12_c3_66 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event12.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_14_c1_67 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event14.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_14_c2_68 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event14.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var companyParticipant_14_c3_69 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event14.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_15_c1_70 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event15.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_15_c2_71 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event15.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var companyParticipant_15_c3_72 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event15.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var companyParticipant_18_c1_73 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event18.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_18_c2_74 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event18.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var companyParticipant_18_c3_75 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event18.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_21_c1_76 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event21.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_21_c2_77 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event21.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var companyParticipant_21_c3_78 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event21.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_22_c1_79 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event22.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_22_c2_80 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event22.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var companyParticipant_22_c3_81 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event22.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_24_c1_82 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event24.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_24_c2_83 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event24.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var companyParticipant_24_c3_84 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event24.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_25_c1_85 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event25.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_25_c2_86 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event25.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var companyParticipant_25_c3_87 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event25.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_28_c1_88 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event28.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_28_c2_89 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event28.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var companyParticipant_28_c3_90 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event28.Guid,
                CompanyGuid = company3.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            _context.Set<CompanyParticipant>().AddRange(new List<CompanyParticipant> { companyParticipant_3_c1_1, companyParticipant_3_c2_2, companyParticipant_3_c3_3, companyParticipant_6_c1_4, companyParticipant_6_c2_5, companyParticipant_6_c3_6, companyParticipant_7_c1_7, companyParticipant_7_c2_8, companyParticipant_7_c3_9, companyParticipant_9_c1_10, companyParticipant_9_c2_11, companyParticipant_9_c3_12, companyParticipant_10_c1_13, companyParticipant_10_c2_14, companyParticipant_10_c3_15, companyParticipant_13_c1_16, companyParticipant_13_c2_17, companyParticipant_13_c3_18, companyParticipant_16_c1_19, companyParticipant_16_c2_20, companyParticipant_16_c3_21, companyParticipant_17_c1_22, companyParticipant_17_c2_23, companyParticipant_17_c3_24, companyParticipant_19_c1_25, companyParticipant_19_c2_26, companyParticipant_19_c3_27, companyParticipant_20_c1_28, companyParticipant_20_c2_29, companyParticipant_20_c3_30, companyParticipant_23_c1_31, companyParticipant_23_c2_32, companyParticipant_23_c3_33, companyParticipant_26_c1_34, companyParticipant_26_c2_35, companyParticipant_26_c3_36, companyParticipant_27_c1_37, companyParticipant_27_c2_38, companyParticipant_27_c3_39, companyParticipant_29_c1_40, companyParticipant_29_c2_41, companyParticipant_29_c3_42, companyParticipant_30_c1_43, companyParticipant_30_c2_44, companyParticipant_30_c3_45, companyParticipant_1_c1_46, companyParticipant_1_c2_47, companyParticipant_1_c3_48, companyParticipant_2_c1_49, companyParticipant_2_c2_50, companyParticipant_2_c3_51, companyParticipant_4_c1_52, companyParticipant_4_c2_53, companyParticipant_4_c3_54, companyParticipant_5_c1_55, companyParticipant_5_c2_56, companyParticipant_5_c3_57, companyParticipant_8_c1_58, companyParticipant_8_c2_59, companyParticipant_8_c3_60, companyParticipant_11_c1_61, companyParticipant_11_c2_62, companyParticipant_11_c3_63, companyParticipant_12_c1_64, companyParticipant_12_c2_65, companyParticipant_12_c3_66, companyParticipant_14_c1_67, companyParticipant_14_c2_68, companyParticipant_14_c3_69, companyParticipant_15_c1_70, companyParticipant_15_c2_71, companyParticipant_15_c3_72, companyParticipant_18_c1_73, companyParticipant_18_c2_74, companyParticipant_18_c3_75, companyParticipant_21_c1_76, companyParticipant_21_c2_77, companyParticipant_21_c3_78, companyParticipant_22_c1_79, companyParticipant_22_c2_80, companyParticipant_22_c3_81, companyParticipant_24_c1_82, companyParticipant_24_c2_83, companyParticipant_24_c3_84, companyParticipant_25_c1_85, companyParticipant_25_c2_86, companyParticipant_25_c3_87, companyParticipant_28_c1_88, companyParticipant_28_c2_89, companyParticipant_28_c3_90 });

            _context.SaveChanges();

            var employeeParticipant_1_c1_e1_1 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event1.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_1_c1_e2_2 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event1.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_1_c2_e1_3 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event1.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_1_c2_e2_4 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event1.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_1_c3_e1_5 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event1.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_1_c3_e2_6 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event1.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_2_c1_e1_7 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event2.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_2_c1_e2_8 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event2.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_2_c2_e1_9 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event2.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_2_c2_e2_10 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event2.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_2_c3_e1_11 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event2.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_2_c3_e2_12 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event2.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_3_c1_e1_13 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event3.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_3_c1_e2_14 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event3.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_3_c2_e1_15 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event3.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_3_c2_e2_16 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event3.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_3_c3_e1_17 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event3.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_3_c3_e2_18 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event3.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_4_c1_e1_19 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event4.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_4_c1_e2_20 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event4.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_4_c2_e1_21 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event4.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_4_c2_e2_22 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event4.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_4_c3_e1_23 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event4.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_4_c3_e2_24 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event4.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_5_c1_e1_25 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event5.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_5_c1_e2_26 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event5.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_5_c2_e1_27 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event5.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_5_c2_e2_28 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event5.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_5_c3_e1_29 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event5.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_5_c3_e2_30 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event5.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_6_c1_e1_31 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event6.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_6_c1_e2_32 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event6.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_6_c2_e1_33 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event6.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_6_c2_e2_34 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event6.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_6_c3_e1_35 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event6.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_6_c3_e2_36 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event6.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_7_c1_e1_37 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event7.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_7_c1_e2_38 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event7.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_7_c2_e1_39 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event7.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_7_c2_e2_40 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event7.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_7_c3_e1_41 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event7.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_7_c3_e2_42 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event7.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_8_c1_e1_43 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event8.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_8_c1_e2_44 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event8.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_8_c2_e1_45 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event4.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_8_c2_e2_46 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event8.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_8_c3_e1_47 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event8.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_8_c3_e2_48 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event8.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_9_c1_e1_49 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event9.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_9_c1_e2_50 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event9.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_9_c2_e1_51 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event9.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_9_c2_e2_52 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event9.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_9_c3_e1_53 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event9.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_9_c3_e2_54 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event9.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_10_c1_e1_55 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event10.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_10_c1_e2_56 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event10.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_10_c2_e1_57 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event10.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_10_c2_e2_58 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event10.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_10_c3_e1_59 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event10.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_10_c3_e2_60 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event10.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_11_c1_e1_61 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event11.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_11_c1_e2_62 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event11.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_11_c2_e1_63 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event11.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_11_c2_e2_64 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event11.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_11_c3_e1_65 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event11.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_11_c3_e2_66 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event11.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_12_c1_e1_67 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event12.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_12_c1_e2_68 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event12.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_12_c2_e1_69 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event12.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_12_c2_e2_70 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event12.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_12_c3_e1_71 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event12.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_12_c3_e2_72 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event12.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_13_c1_e1_73 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event13.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_13_c1_e2_74 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event13.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_13_c2_e1_75 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event13.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_13_c2_e2_76 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event13.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_13_c3_e1_77 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event13.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_13_c3_e2_78 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event13.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_14_c1_e1_79 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event14.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_14_c1_e2_80 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event14.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_14_c2_e1_81 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event14.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_14_c2_e2_82 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event14.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_14_c3_e1_83 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event6.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_14_c3_e2_84 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event6.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_15_c1_e1_85 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event15.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_15_c1_e2_86 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event15.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_15_c2_e1_87 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event15.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_15_c2_e2_88 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event15.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_15_c3_e1_89 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event15.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_15_c3_e2_90 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event15.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_16_c1_e1_91 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event16.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_16_c1_e2_92 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event16.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_16_c2_e1_93 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event16.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_16_c2_e2_94 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event16.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_16_c3_e1_95 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event8.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_16_c3_e2_96 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event16.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_17_c1_e1_97 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event17.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_17_c1_e2_98 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event17.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_17_c2_e1_99 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event17.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_17_c2_e2_100 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event17.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_17_c3_e1_101 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event17.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_17_c3_e2_102 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event17.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_18_c1_e1_103 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event18.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_18_c1_e2_104 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event18.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_18_c2_e1_105 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event18.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_18_c2_e2_106 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event18.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_18_c3_e1_107 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event18.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_18_c3_e2_108 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event18.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_19_c1_e1_109 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event19.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_19_c1_e2_110 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event19.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_19_c2_e1_111 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event19.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_19_c2_e2_112 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event19.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_19_c3_e1_113 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event19.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_19_c3_e2_114 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event19.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_20_c1_e1_115 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event20.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_20_c1_e2_116 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event20.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_20_c2_e1_117 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event20.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_20_c2_e2_118 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event20.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_20_c3_e1_119 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event20.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_20_c3_e2_120 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event20.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_21_c1_e1_121 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event21.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_21_c1_e2_122 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event21.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_21_c2_e1_123 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event21.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_21_c2_e2_124 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event21.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_21_c3_e1_125 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event21.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_21_c3_e2_126 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event21.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_22_c1_e1_127 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event22.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_22_c1_e2_128 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event22.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_22_c2_e1_129 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event22.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_22_c2_e2_130 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event22.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_22_c3_e1_131 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event22.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_22_c3_e2_132 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event22.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_23_c1_e1_133 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event23.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_23_c1_e2_134 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event23.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_23_c2_e1_135 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event23.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_23_c2_e2_136 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event23.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_23_c3_e1_137 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event23.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_23_c3_e2_138 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event23.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_24_c1_e1_139 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event24.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_24_c1_e2_140 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event24.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_24_c2_e1_141 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event24.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_24_c2_e2_142 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event24.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_24_c3_e1_143 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event24.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_24_c3_e2_144 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event24.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_25_c1_e1_145 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event25.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_25_c1_e2_146 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event25.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_25_c2_e1_147 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event25.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_25_c2_e2_148 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event25.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_25_c3_e1_149 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event25.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_25_c3_e2_150 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event25.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_26_c1_e1_151 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event26.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_26_c1_e2_152 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event26.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_26_c2_e1_153 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event26.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_26_c2_e2_154 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event26.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_26_c3_e1_155 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event26.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_26_c3_e2_156 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event26.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_27_c1_e1_157 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event27.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_27_c1_e2_158 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event27.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_27_c2_e1_159 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event27.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_27_c2_e2_160 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event27.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_27_c3_e1_161 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event11.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_27_c3_e2_162 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event27.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_28_c1_e1_163 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event28.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_28_c1_e2_164 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event28.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_28_c2_e1_165 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event28.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_28_c2_e2_166 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event28.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_28_c3_e1_167 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event28.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_28_c3_e2_168 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event28.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_29_c1_e1_169 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event29.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_29_c1_e2_170 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event29.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_29_c2_e1_171 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event29.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_29_c2_e2_172 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event29.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_29_c3_e1_173 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event29.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_29_c3_e2_174 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event29.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_30_c1_e1_175 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event30.Guid,
                EmployeeGuid = employee1.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_30_c1_e2_176 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event30.Guid,
                EmployeeGuid = employee2.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_30_c2_e1_177 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event30.Guid,
                EmployeeGuid = employee11.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_30_c2_e2_178 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event30.Guid,
                EmployeeGuid = employee12.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_30_c3_e1_179 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event30.Guid,
                EmployeeGuid = employee21.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var employeeParticipant_30_c3_e2_180 = new EmployeeParticipant
            {

                Guid = new Guid(),
                EventGuid = event30.Guid,
                EmployeeGuid = employee22.Guid,
                Status = InviteStatusLevel.Pending,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };



            _context.Set<EmployeeParticipant>().AddRange(new List<EmployeeParticipant> { employeeParticipant_1_c1_e1_1, employeeParticipant_1_c1_e2_2, employeeParticipant_1_c2_e1_3, employeeParticipant_1_c2_e2_4, employeeParticipant_1_c3_e1_5, employeeParticipant_1_c3_e2_6, employeeParticipant_2_c1_e1_7, employeeParticipant_2_c1_e2_8, employeeParticipant_2_c2_e1_9, employeeParticipant_2_c2_e2_10, employeeParticipant_2_c3_e1_11, employeeParticipant_2_c3_e2_12, employeeParticipant_3_c1_e1_13, employeeParticipant_3_c1_e2_14, employeeParticipant_3_c2_e1_15, employeeParticipant_3_c2_e2_16, employeeParticipant_3_c3_e1_17, employeeParticipant_3_c3_e2_18, employeeParticipant_4_c1_e1_19, employeeParticipant_4_c1_e2_20, employeeParticipant_4_c2_e1_21, employeeParticipant_4_c2_e2_22, employeeParticipant_4_c3_e1_23, employeeParticipant_4_c3_e2_24, employeeParticipant_5_c1_e1_25, employeeParticipant_5_c1_e2_26, employeeParticipant_5_c2_e1_27, employeeParticipant_5_c2_e2_28, employeeParticipant_5_c3_e1_29, employeeParticipant_5_c3_e2_30, employeeParticipant_6_c1_e1_31, employeeParticipant_6_c1_e2_32, employeeParticipant_6_c2_e1_33, employeeParticipant_6_c2_e2_34, employeeParticipant_6_c3_e1_35, employeeParticipant_6_c3_e2_36, employeeParticipant_7_c1_e1_37, employeeParticipant_7_c1_e2_38, employeeParticipant_7_c2_e1_39, employeeParticipant_7_c2_e2_40, employeeParticipant_7_c3_e1_41, employeeParticipant_7_c3_e2_42, employeeParticipant_8_c1_e1_43, employeeParticipant_8_c1_e2_44, employeeParticipant_8_c2_e1_45, employeeParticipant_8_c2_e2_46, employeeParticipant_8_c3_e1_47, employeeParticipant_8_c3_e2_48, employeeParticipant_9_c1_e1_49, employeeParticipant_9_c1_e2_50, employeeParticipant_9_c2_e1_51, employeeParticipant_9_c2_e2_52, employeeParticipant_9_c3_e1_53, employeeParticipant_9_c3_e2_54, employeeParticipant_10_c1_e1_55, employeeParticipant_10_c1_e2_56, employeeParticipant_10_c2_e1_57, employeeParticipant_10_c2_e2_58, employeeParticipant_10_c3_e1_59, employeeParticipant_10_c3_e2_60, employeeParticipant_11_c1_e1_61, employeeParticipant_11_c1_e2_62, employeeParticipant_11_c2_e1_63, employeeParticipant_11_c2_e2_64, employeeParticipant_11_c3_e1_65, employeeParticipant_11_c3_e2_66, employeeParticipant_12_c1_e1_67, employeeParticipant_12_c1_e2_68, employeeParticipant_12_c2_e1_69, employeeParticipant_12_c2_e2_70, employeeParticipant_12_c3_e1_71, employeeParticipant_12_c3_e2_72, employeeParticipant_13_c1_e1_73, employeeParticipant_13_c1_e2_74, employeeParticipant_13_c2_e1_75, employeeParticipant_13_c2_e2_76, employeeParticipant_13_c3_e1_77, employeeParticipant_13_c3_e2_78, employeeParticipant_14_c1_e1_79, employeeParticipant_14_c1_e2_80, employeeParticipant_14_c2_e1_81, employeeParticipant_14_c2_e2_82, employeeParticipant_14_c3_e1_83, employeeParticipant_14_c3_e2_84, employeeParticipant_15_c1_e1_85, employeeParticipant_15_c1_e2_86, employeeParticipant_15_c2_e1_87, employeeParticipant_15_c2_e2_88, employeeParticipant_15_c3_e1_89, employeeParticipant_15_c3_e2_90, employeeParticipant_16_c1_e1_91, employeeParticipant_16_c1_e2_92, employeeParticipant_16_c2_e1_93, employeeParticipant_16_c2_e2_94, employeeParticipant_16_c3_e1_95, employeeParticipant_16_c3_e2_96, employeeParticipant_17_c1_e1_97, employeeParticipant_17_c1_e2_98, employeeParticipant_17_c2_e1_99, employeeParticipant_17_c2_e2_100, employeeParticipant_17_c3_e1_101, employeeParticipant_17_c3_e2_102, employeeParticipant_18_c1_e1_103, employeeParticipant_18_c1_e2_104, employeeParticipant_18_c2_e1_105, employeeParticipant_18_c2_e2_106, employeeParticipant_18_c3_e1_107, employeeParticipant_18_c3_e2_108, employeeParticipant_19_c1_e1_109, employeeParticipant_19_c1_e2_110, employeeParticipant_19_c2_e1_111, employeeParticipant_19_c2_e2_112, employeeParticipant_19_c3_e1_113, employeeParticipant_19_c3_e2_114, employeeParticipant_20_c1_e1_115, employeeParticipant_20_c1_e2_116, employeeParticipant_20_c2_e1_117, employeeParticipant_20_c2_e2_118, employeeParticipant_20_c3_e1_119, employeeParticipant_20_c3_e2_120, employeeParticipant_17_c3_e1_101, employeeParticipant_17_c3_e2_102, employeeParticipant_18_c1_e1_103, employeeParticipant_18_c1_e2_104, employeeParticipant_18_c2_e1_105, employeeParticipant_18_c2_e2_106, employeeParticipant_18_c3_e1_107, employeeParticipant_18_c3_e2_108, employeeParticipant_19_c1_e1_109, employeeParticipant_19_c1_e2_110, employeeParticipant_19_c2_e1_111, employeeParticipant_19_c2_e2_112, employeeParticipant_19_c3_e1_113, employeeParticipant_19_c3_e2_114, employeeParticipant_20_c1_e1_115, employeeParticipant_20_c1_e2_116, employeeParticipant_20_c2_e1_117, employeeParticipant_20_c2_e2_118, employeeParticipant_20_c3_e1_119, employeeParticipant_20_c3_e2_120, employeeParticipant_21_c1_e1_121, employeeParticipant_21_c1_e2_122, employeeParticipant_21_c2_e1_123, employeeParticipant_21_c2_e2_124, employeeParticipant_21_c3_e1_125, employeeParticipant_21_c3_e2_126, employeeParticipant_22_c1_e1_127, employeeParticipant_22_c1_e2_128, employeeParticipant_22_c2_e1_129, employeeParticipant_22_c2_e2_130, employeeParticipant_22_c3_e1_131, employeeParticipant_22_c3_e2_132, employeeParticipant_23_c1_e1_133, employeeParticipant_23_c1_e2_134, employeeParticipant_23_c2_e1_135, employeeParticipant_23_c2_e2_136, employeeParticipant_23_c3_e1_137, employeeParticipant_23_c3_e2_138, employeeParticipant_24_c1_e1_139, employeeParticipant_24_c1_e2_140, employeeParticipant_24_c2_e1_141, employeeParticipant_24_c2_e2_142, employeeParticipant_24_c3_e1_143, employeeParticipant_24_c3_e2_144, employeeParticipant_25_c1_e1_145, employeeParticipant_25_c1_e2_146, employeeParticipant_25_c2_e1_147, employeeParticipant_25_c2_e2_148, employeeParticipant_25_c3_e1_149, employeeParticipant_25_c3_e2_150, employeeParticipant_26_c1_e1_151, employeeParticipant_26_c1_e2_152, employeeParticipant_26_c2_e1_153, employeeParticipant_26_c2_e2_154, employeeParticipant_26_c3_e1_155, employeeParticipant_26_c3_e2_156, employeeParticipant_27_c1_e1_157, employeeParticipant_27_c1_e2_158, employeeParticipant_27_c2_e1_159, employeeParticipant_27_c2_e2_160, employeeParticipant_27_c3_e1_161, employeeParticipant_27_c3_e2_162, employeeParticipant_28_c1_e1_163, employeeParticipant_28_c1_e2_164, employeeParticipant_28_c2_e1_165, employeeParticipant_28_c2_e2_166, employeeParticipant_28_c3_e1_167, employeeParticipant_28_c3_e2_168, employeeParticipant_29_c1_e1_169, employeeParticipant_29_c1_e2_170, employeeParticipant_29_c2_e1_171, employeeParticipant_29_c2_e2_172, employeeParticipant_29_c3_e1_173, employeeParticipant_29_c3_e2_174, employeeParticipant_30_c1_e1_175, employeeParticipant_30_c1_e2_176, employeeParticipant_30_c2_e1_177, employeeParticipant_30_c2_e2_178, employeeParticipant_30_c3_e1_179, employeeParticipant_30_c3_e2_180, });

            _context.SaveChanges();




            var eventpayment2 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account2.Guid,
                EventGuid = event3.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment3 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account12.Guid,
                EventGuid = event3.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment4 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account3.Guid,
                EventGuid = event3.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment5 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account4.Guid,
                EventGuid = event3.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment6 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account15.Guid,
                EventGuid = event3.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment7 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account16.Guid,
                EventGuid = event3.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment8 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account25.Guid,
                EventGuid = event3.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment9 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account26.Guid,
                EventGuid = event3.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };


            var eventpayment11 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account2.Guid,
                EventGuid = event6.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment12 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account12.Guid,
                EventGuid = event6.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment13 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account3.Guid,
                EventGuid = event6.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending
            };

            var eventpayment14 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account4.Guid,
                EventGuid = event6.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment15 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account15.Guid,
                EventGuid = event6.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment16 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account16.Guid,
                EventGuid = event6.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment17 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account25.Guid,
                EventGuid = event6.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment18 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account26.Guid,
                EventGuid = event6.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment20 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account2.Guid,
                EventGuid = event7.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment21 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account12.Guid,
                EventGuid = event7.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment22 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account3.Guid,
                EventGuid = event7.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment23 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account4.Guid,
                EventGuid = event7.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };


            var eventpayment24 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account15.Guid,
                EventGuid = event7.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment25 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account16.Guid,
                EventGuid = event7.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment26 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account25.Guid,
                EventGuid = event7.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment27 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account26.Guid,
                EventGuid = event7.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };


            var eventpayment29 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account2.Guid,
                EventGuid = event9.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment30 = new EventPayment
            {

                Guid = new Guid(),
                AccountGuid = account12.Guid,
                EventGuid = event9.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };


            var eventpayment31 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account3.Guid,
                EventGuid = event9.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment32 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account4.Guid,
                EventGuid = event9.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };


            var eventpayment33 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account15.Guid,
                EventGuid = event9.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment34 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account16.Guid,
                EventGuid = event9.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment35 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account25.Guid,
                EventGuid = event9.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment36 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account26.Guid,
                EventGuid = event9.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };


            var eventpayment38 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account2.Guid,
                EventGuid = event10.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment39 = new EventPayment
            {

                Guid = new Guid(),
                AccountGuid = account12.Guid,
                EventGuid = event10.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };


            var eventpayment40 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account3.Guid,
                EventGuid = event10.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment41 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account4.Guid,
                EventGuid = event10.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };


            var eventpayment42 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account15.Guid,
                EventGuid = event10.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment43 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account16.Guid,
                EventGuid = event10.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment44 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account25.Guid,
                EventGuid = event10.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment45 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account26.Guid,
                EventGuid = event10.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment46 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account1.Guid,
                EventGuid = event13.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };



            var eventpayment48 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account12.Guid,
                EventGuid = event13.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment49 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account13.Guid,
                EventGuid = event13.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment50 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account4.Guid,
                EventGuid = event13.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment51 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account15.Guid,
                EventGuid = event13.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment52 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account16.Guid,
                EventGuid = event13.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment53 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account25.Guid,
                EventGuid = event13.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment54 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account26.Guid,
                EventGuid = event13.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment55 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account1.Guid,
                EventGuid = event16.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };


            var eventpayment57 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account12.Guid,
                EventGuid = event16.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment58 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account3.Guid,
                EventGuid = event16.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending
            };

            var eventpayment59 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account4.Guid,
                EventGuid = event16.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment60 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account15.Guid,
                EventGuid = event16.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment61 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account16.Guid,
                EventGuid = event16.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment62 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account25.Guid,
                EventGuid = event16.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment63 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account26.Guid,
                EventGuid = event16.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment64 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account1.Guid,
                EventGuid = event17.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };


            var eventpayment66 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account12.Guid,
                EventGuid = event17.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment67 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account3.Guid,
                EventGuid = event17.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment68 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account4.Guid,
                EventGuid = event17.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };


            var eventpayment69 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account15.Guid,
                EventGuid = event17.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment70 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account16.Guid,
                EventGuid = event17.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment71 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account25.Guid,
                EventGuid = event17.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment72 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account26.Guid,
                EventGuid = event17.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment73 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account1.Guid,
                EventGuid = event19.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };


            var eventpayment75 = new EventPayment
            {

                Guid = new Guid(),
                AccountGuid = account12.Guid,
                EventGuid = event19.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };


            var eventpayment76 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account3.Guid,
                EventGuid = event19.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment77 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account4.Guid,
                EventGuid = event19.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };


            var eventpayment78 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account15.Guid,
                EventGuid = event19.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment79 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account16.Guid,
                EventGuid = event19.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment80 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account25.Guid,
                EventGuid = event19.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment81 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account26.Guid,
                EventGuid = event19.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment82 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account1.Guid,
                EventGuid = event20.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };


            var eventpayment84 = new EventPayment
            {

                Guid = new Guid(),
                AccountGuid = account12.Guid,
                EventGuid = event20.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };


            var eventpayment85 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account3.Guid,
                EventGuid = event20.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment86 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account4.Guid,
                EventGuid = event20.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };


            var eventpayment87 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account15.Guid,
                EventGuid = event20.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment88 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account16.Guid,
                EventGuid = event20.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment89 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account25.Guid,
                EventGuid = event20.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment90 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account26.Guid,
                EventGuid = event20.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment91 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account1.Guid,
                EventGuid = event23.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };


            var eventpayment92 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account2.Guid,
                EventGuid = event23.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment94 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account13.Guid,
                EventGuid = event23.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment95 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account4.Guid,
                EventGuid = event23.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment96 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account15.Guid,
                EventGuid = event23.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment97 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account16.Guid,
                EventGuid = event23.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment98 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account25.Guid,
                EventGuid = event23.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment99 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account26.Guid,
                EventGuid = event23.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment100 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account1.Guid,
                EventGuid = event26.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment101 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account2.Guid,
                EventGuid = event26.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };



            var eventpayment103 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account3.Guid,
                EventGuid = event26.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending
            };

            var eventpayment104 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account4.Guid,
                EventGuid = event26.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment105 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account15.Guid,
                EventGuid = event26.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment106 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account16.Guid,
                EventGuid = event26.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment107 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account25.Guid,
                EventGuid = event26.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment108 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account26.Guid,
                EventGuid = event26.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment109 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account1.Guid,
                EventGuid = event27.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment110 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account2.Guid,
                EventGuid = event27.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };



            var eventpayment112 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account3.Guid,
                EventGuid = event27.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment113 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account4.Guid,
                EventGuid = event27.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };


            var eventpayment114 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account15.Guid,
                EventGuid = event27.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment115 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account16.Guid,
                EventGuid = event27.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment116 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account25.Guid,
                EventGuid = event27.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment117 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account26.Guid,
                EventGuid = event27.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment118 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account1.Guid,
                EventGuid = event29.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment119 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account2.Guid,
                EventGuid = event29.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };




            var eventpayment121 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account3.Guid,
                EventGuid = event29.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment122 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account4.Guid,
                EventGuid = event29.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };


            var eventpayment123 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account15.Guid,
                EventGuid = event29.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment124 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account16.Guid,
                EventGuid = event29.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment125 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account25.Guid,
                EventGuid = event29.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment126 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account26.Guid,
                EventGuid = event29.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment127 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account1.Guid,
                EventGuid = event30.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment128 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account2.Guid,
                EventGuid = event30.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };



            var eventpayment130 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account3.Guid,
                EventGuid = event30.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment131 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account4.Guid,
                EventGuid = event30.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };


            var eventpayment132 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account15.Guid,
                EventGuid = event30.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment133 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account16.Guid,
                EventGuid = event30.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment134 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account25.Guid,
                EventGuid = event30.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };

            var eventpayment135 = new EventPayment
            {
                Guid = new Guid(),
                AccountGuid = account26.Guid,
                EventGuid = event30.Guid,
                VaNumber = GenerateHandler.RandomVa(),
                PaymentImage = "",
                IsValid = true,
                BankGuid = GetRandomBankGuid(),
                StatusPayment = StatusPayment.Pending

            };


            _context.Set<EventPayment>().AddRange(new List<EventPayment>
            { eventpayment2, eventpayment3, eventpayment4, eventpayment5, eventpayment6, eventpayment7, eventpayment8, eventpayment9,  eventpayment11, eventpayment12, eventpayment13, eventpayment14, eventpayment15, eventpayment16, eventpayment17, eventpayment18,  eventpayment20, eventpayment21, eventpayment22, eventpayment23, eventpayment24, eventpayment25, eventpayment26, eventpayment27, eventpayment29, eventpayment30, eventpayment31, eventpayment32, eventpayment33, eventpayment34, eventpayment35, eventpayment36,  eventpayment38, eventpayment39, eventpayment40, eventpayment41,  eventpayment42, eventpayment43, eventpayment44, eventpayment45, eventpayment46, eventpayment48, eventpayment49, eventpayment50, eventpayment51, eventpayment52, eventpayment53, eventpayment54, eventpayment55,  eventpayment57, eventpayment58, eventpayment59, eventpayment60, eventpayment61, eventpayment62, eventpayment63, eventpayment64,  eventpayment66, eventpayment67, eventpayment68, eventpayment69, eventpayment70, eventpayment71, eventpayment72, eventpayment73,  eventpayment75, eventpayment76, eventpayment77, eventpayment78, eventpayment79, eventpayment80, eventpayment81, eventpayment82, eventpayment84, eventpayment85, eventpayment86, eventpayment87, eventpayment88, eventpayment89, eventpayment90, eventpayment91, eventpayment92,  eventpayment94, eventpayment95, eventpayment96, eventpayment97, eventpayment98, eventpayment99, eventpayment100, eventpayment101,   eventpayment103, eventpayment104, eventpayment105, eventpayment106, eventpayment107, eventpayment108, eventpayment109, eventpayment110,  eventpayment112, eventpayment113, eventpayment114, eventpayment115, eventpayment116, eventpayment117, eventpayment118, eventpayment119,  eventpayment121, eventpayment122, eventpayment123, eventpayment124, eventpayment125, eventpayment126, eventpayment127, eventpayment128,  eventpayment130, eventpayment131, eventpayment132, eventpayment133, eventpayment134, eventpayment135});

            _context.SaveChanges();

            var sysadmin1 = new SysAdmin
            {
                Guid = new Guid(),
                Name = "SysAdmin1",
                BankAccountNumber = "12345678910",
                AccountGuid = account11.Guid
            };


            _context.Set<SysAdmin>().AddRange(new List<SysAdmin> { sysadmin1 });

            _context.SaveChanges();

            var eventdoc1 = new EventDoc
            {
                Guid = new Guid(),
                Documentation = "Event Ini Merupakan Event Seminar Cyber Security",
                EventGuid = event1.Guid

            };

            var eventdoc2 = new EventDoc
            {
                Guid = new Guid(),
                Documentation = "Event Ini Merupakan Event Seminar Kemerdekaan",
                EventGuid = event2.Guid

            };

            var eventdoc3 = new EventDoc
            {
                Guid = new Guid(),
                Documentation = "Event Ini Merupakan Event Workshop Create A Good Branding",
                EventGuid = event3.Guid
            };

            var eventdoc4 = new EventDoc
            {
                Guid = new Guid(),
                Documentation = "Event Ini Merupakan Event Interview PT.JKI",
                EventGuid = event4.Guid
            };

            var eventdoc5 = new EventDoc
            {
                Guid = new Guid(),
                Documentation = "Event Ini Merupakan Event Interview PT.KLM",
                EventGuid = event5.Guid

            };

            _context.Set<EventDoc>().AddRange(new List<EventDoc> { eventdoc1, eventdoc2, eventdoc3, eventdoc4, eventdoc5 });

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
            var sysadmins = _context.Set<SysAdmin>().Where(sa => sa.Guid != new Guid());
            _context.Set<SysAdmin>().RemoveRange(sysadmins);
            _context.SaveChanges();

            var eventdocs = _context.Set<EventDoc>().Where(ed => ed.Guid != new Guid());
            _context.Set<EventDoc>().RemoveRange(eventdocs);
            _context.SaveChanges();

            var eventpayments = _context.Set<EventPayment>().Where(evp => evp.Guid != new Guid());
            _context.Set<EventPayment>().RemoveRange(eventpayments);
            _context.SaveChanges();

            var registerpayments = _context.Set<RegisterPayment>().Where(rp => rp.Guid != new Guid());
            _context.Set<RegisterPayment>().RemoveRange(registerpayments);
            _context.SaveChanges();

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

    public Guid GetRandomBankGuid()
    {
        var random = new Random();
        var banks = _context.Set<Bank>().ToList();

        if (banks.Count == 0)
        {
            // If there are no banks in the database, return Guid.Empty or throw an exception.
            // Here, we return Guid.Empty as a default value (you can modify this).
            return Guid.Empty;
        }

        var randomIndex = random.Next(0, banks.Count-1);
        return banks[randomIndex].Guid;
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
                ModifiedDate = DateTime.Now
            };

            var mandiri = new Bank
            {
                Guid = new Guid(),
                Code = "BM",
                Name = "Bank Mandiri",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var bsi = new Bank
            {
                Guid = new Guid(),
                Code = "BSI",
                Name = "Bank Syariah Indonesia",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var bni = new Bank
            {
                Guid = new Guid(),
                Code = "BNI",
                Name = "Bank Nasional Indonesia",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var bca = new Bank
            {
                Guid = new Guid(),
                Code = "BCA",
                Name = "Bank Central Asia",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            _context.Set<Bank>().AddRange(new List<Bank> { bri, mandiri, bsi, bni, bca });

            _context.SaveChanges();

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
        }


    }

    public void GeneratePayments()
    {
        using var transaction = _context.Database.BeginTransaction();

        try
        {

            var registerpayment1 = new RegisterPayment
            {
                Guid = new Guid(),
                CompanyGuid = _context.Set<Company>().FirstOrDefault(c => c.Name == "PT.ABC").Guid,
                VaNumber = GenerateHandler.RandomVa(),
                Price = 500000,
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Paid


            };

            var registerpayment2 = new RegisterPayment
            {
                Guid = new Guid(),
                CompanyGuid = _context.Set<Company>().FirstOrDefault(c => c.Name == "PT.XYZ").Guid,
                VaNumber = GenerateHandler.RandomVa(),
                Price = 500000,
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Paid
            };

            var registerpayment3 = new RegisterPayment
            {
                Guid = new Guid(),
                CompanyGuid = _context.Set<Company>().FirstOrDefault(c => c.Name == "PT.RAY").Guid,
                VaNumber = GenerateHandler.RandomVa(),
                Price = 500000,
                PaymentImage = "",
                IsValid = true,
                BankGuid = _context.Set<Bank>().FirstOrDefault(b => b.Code == "BSI").Guid,
                StatusPayment = StatusPayment.Paid
            };

            _context.Set<RegisterPayment>().AddRange(new List<RegisterPayment>
            { registerpayment1, registerpayment2, registerpayment3});

            _context.SaveChanges();
            transaction.Commit();
        }

        catch
        {
            transaction.Rollback();
        }


    }

    public Bank? GetRandomBank()
    {
        var getBanks = _context.Set<Bank>().ToList();
        if (getBanks is null || getBanks.Count() == 0)
        {
            return null; // Atau tindakan lain jika daftar kosong.
        }

        Random random = new Random();
        int randomIndex = random.Next(0, getBanks.Count() - 1); // Mendapatkan indeks acak dalam rentang [0, count-1].
        var randomBank = getBanks[randomIndex]; // Mendapatkan bank secara acak.

        return randomBank ?? null;
    }
}

