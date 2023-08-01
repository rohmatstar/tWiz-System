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
                Password = HashingHandler.HashPassword("!Employee123"),
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


            _context.Set<Account>().AddRange(new List<Account> { account1, account2, account3, account4, account5, account6,account7,account8,account9,account10, account11, account12, account13, account14, account15, account16, account17, account18, account19, account20, account21,account22,account23,account24, account25, account26, account27, account28, account29, account30, account31, account32, account33, account34 });
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
                AccountGuid= account6.Guid,
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
                RoleGuid =  companyRole.Guid,
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

            _context.Set<AccountRole>().AddRange(new List<AccountRole> { account1Role, account2Role, account3Role, account4Role, account5Role, account6role, account7role, account8role, account9role, account10role, account11role, account12role, account13role, account14role , account15role, account16role, account17role, account18role, account19role, account20role, account21role, account22role, account23role, account24role, account25role, account26role, account27role, account28role, account29role, account30role, account31role, account32role, account33role, account34role});
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

            var company3 = new Company
            {
                Guid = new Guid(),
                Name = "PT.Ray",
                Address = "JL.Bojong Koneng",
                PhoneNumber = "085555867777",
                AccountGuid = account12.Guid,
                BankAccountNumber = "55555726656",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            _context.Set<Company>().AddRange(new List<Company> { company1, company2, company3});
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
                PhoneNumber = "085772144566",
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
                PhoneNumber = "085772144555",
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
                PhoneNumber = "085772144533",
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
                PhoneNumber = "085772144533",
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
                PhoneNumber = "085772144533",
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
                PhoneNumber = "085772144544",
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
                PhoneNumber = "085772144555",
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
                PhoneNumber = "085772144577",
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
                AccountGuid = account25.Guid,
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
                AccountGuid = account26.Guid,
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
                AccountGuid = account27.Guid,
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
                AccountGuid = account28.Guid,
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
                AccountGuid = account29.Guid,
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
                AccountGuid = account30.Guid,
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
                AccountGuid = account31.Guid,
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
                AccountGuid = account32.Guid,
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
                AccountGuid = account33.Guid,
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
                CreatedBy = company1.Guid,
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
                IsPublished = false,
                Place = "PT.ABC",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event9 = new Event
            {
                Guid = new Guid(),
                Name = "Interview",
                Quota = 3,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 09, 10, 8, 30, 0),
                EndDate = new DateTime(2023, 09, 15, 12, 0, 0),
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

            var event10 = new Event
            {
                Guid = new Guid(),
                Name = "Interview",
                Quota = 3,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 05, 12, 8, 30, 0),
                EndDate = new DateTime(2023, 05, 12, 12, 0, 0),
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

            var event11 = new Event
            {
                Guid = new Guid(),
                Name = "Interview",
                Quota = 3,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 05, 12, 8, 30, 0),
                EndDate = new DateTime(2023, 05, 12, 12, 0, 0),
                Description = "Interview client",
                Category = "Interview",
                CreatedBy = company2.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = false,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event12 = new Event
            {
                Guid = new Guid(),
                Name = "Interview",
                Quota = 3,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 05, 12, 8, 30, 0),
                EndDate = new DateTime(2023, 05, 12, 12, 0, 0),
                Description = "Interview client",
                Category = "Interview",
                CreatedBy = company2.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = false,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event13 = new Event
            {
                Guid = new Guid(),
                Name = "Interview",
                Quota = 3,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 05, 12, 8, 30, 0),
                EndDate = new DateTime(2023, 05, 12, 12, 0, 0),
                Description = "Interview client",
                Category = "Interview",
                CreatedBy = company2.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = false,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event14 = new Event
            {
                Guid = new Guid(),
                Name = "Interview",
                Quota = 3,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 05, 12, 8, 30, 0),
                EndDate = new DateTime(2023, 05, 12, 12, 0, 0),
                Description = "Interview client",
                Category = "Interview",
                CreatedBy = company2.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = false,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event15 = new Event
            {
                Guid = new Guid(),
                Name = "Interview",
                Quota = 3,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 05, 12, 8, 30, 0),
                EndDate = new DateTime(2023, 05, 12, 12, 0, 0),
                Description = "Interview client",
                Category = "Interview",
                CreatedBy = company2.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = false,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event16 = new Event
            {
                Guid = new Guid(),
                Name = "Interview",
                Quota = 3,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 05, 12, 8, 30, 0),
                EndDate = new DateTime(2023, 05, 12, 12, 0, 0),
                Description = "Interview client",
                Category = "Interview",
                CreatedBy = company2.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = false,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event17 = new Event
            {
                Guid = new Guid(),
                Name = "Interview",
                Quota = 3,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 05, 12, 8, 30, 0),
                EndDate = new DateTime(2023, 05, 12, 12, 0, 0),
                Description = "Interview client",
                Category = "Interview",
                CreatedBy = company2.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = false,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event18 = new Event
            {
                Guid = new Guid(),
                Name = "Interview",
                Quota = 3,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 05, 12, 8, 30, 0),
                EndDate = new DateTime(2023, 05, 12, 12, 0, 0),
                Description = "Interview client",
                Category = "Interview",
                CreatedBy = company2.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = false,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event19 = new Event
            {
                Guid = new Guid(),
                Name = "Interview",
                Quota = 3,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 05, 12, 8, 30, 0),
                EndDate = new DateTime(2023, 05, 12, 12, 0, 0),
                Description = "Interview client",
                Category = "Interview",
                CreatedBy = company2.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = false,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event20 = new Event
            {
                Guid = new Guid(),
                Name = "Interview",
                Quota = 3,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 05, 12, 8, 30, 0),
                EndDate = new DateTime(2023, 05, 12, 12, 0, 0),
                Description = "Interview client",
                Category = "Interview",
                CreatedBy = company2.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = false,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event21 = new Event
            {
                Guid = new Guid(),
                Name = "Interview",
                Quota = 3,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 05, 12, 8, 30, 0),
                EndDate = new DateTime(2023, 05, 12, 12, 0, 0),
                Description = "Interview client",
                Category = "Interview",
                CreatedBy = company3.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = false,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event22 = new Event
            {
                Guid = new Guid(),
                Name = "Interview",
                Quota = 3,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 05, 12, 8, 30, 0),
                EndDate = new DateTime(2023, 05, 12, 12, 0, 0),
                Description = "Interview client",
                Category = "Interview",
                CreatedBy = company3.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = false,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event23 = new Event
            {
                Guid = new Guid(),
                Name = "Interview",
                Quota = 3,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 05, 12, 8, 30, 0),
                EndDate = new DateTime(2023, 05, 12, 12, 0, 0),
                Description = "Interview client",
                Category = "Interview",
                CreatedBy = company3.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = false,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event24 = new Event
            {
                Guid = new Guid(),
                Name = "Interview",
                Quota = 3,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 05, 12, 8, 30, 0),
                EndDate = new DateTime(2023, 05, 12, 12, 0, 0),
                Description = "Interview client",
                Category = "Interview",
                CreatedBy = company3.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = false,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event25 = new Event
            {
                Guid = new Guid(),
                Name = "Interview",
                Quota = 3,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 05, 12, 8, 30, 0),
                EndDate = new DateTime(2023, 05, 12, 12, 0, 0),
                Description = "Interview client",
                Category = "Interview",
                CreatedBy = company3.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = false,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event26 = new Event
            {
                Guid = new Guid(),
                Name = "Interview",
                Quota = 3,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 05, 12, 8, 30, 0),
                EndDate = new DateTime(2023, 05, 12, 12, 0, 0),
                Description = "Interview client",
                Category = "Interview",
                CreatedBy = company3.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = false,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event27 = new Event
            {
                Guid = new Guid(),
                Name = "Interview",
                Quota = 3,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 05, 12, 8, 30, 0),
                EndDate = new DateTime(2023, 05, 12, 12, 0, 0),
                Description = "Interview client",
                Category = "Interview",
                CreatedBy = company3.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = false,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event28 = new Event
            {
                Guid = new Guid(),
                Name = "Interview",
                Quota = 3,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 05, 12, 8, 30, 0),
                EndDate = new DateTime(2023, 05, 12, 12, 0, 0),
                Description = "Interview client",
                Category = "Interview",
                CreatedBy = company3.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = false,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var event29 = new Event
            {
                Guid = new Guid(),
                Name = "Interview",
                Quota = 3,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 05, 12, 8, 30, 0),
                EndDate = new DateTime(2023, 05, 12, 12, 0, 0),
                Description = "Interview client",
                Category = "Interview",
                CreatedBy = company3.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = false,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            var event30 = new Event
            {
                Guid = new Guid(),
                Name = "Interview",
                Quota = 3,
                UsedQuota = 0,
                StartDate = new DateTime(2023, 05, 12, 8, 30, 0),
                EndDate = new DateTime(2023, 05, 12, 12, 0, 0),
                Description = "Interview client",
                Category = "Interview",
                CreatedBy = company3.Guid,
                IsPaid = false,
                Price = 0,
                IsActive = true,
                Status = EventStatus.Online,
                IsPublished = false,
                Place = "www.zoom.com",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };


            _context.Set<Event>().AddRange(new List<Event> { event1, event2, event3, event4, event5, event6, event7, event8, event9, event10,event11, event12, event13, event14, event15, event16, event17, event18, event19, event20, event21, event22, event23, event24, event25, event26, event27, event28, event29, event30 });
            _context.SaveChanges();

            var companyParticipant_1_1 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event1.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Accepted,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_2_1 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event2.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Accepted,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_3_1 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event3.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Accepted,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_4_1 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event4.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Accepted,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_5_1 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event5.Guid,
                CompanyGuid = company2.Guid,
                Status = InviteStatusLevel.Accepted,
                IsPresent = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var companyParticipant_6_1 = new CompanyParticipant
            {
                Guid = new Guid(),
                EventGuid = event6.Guid,
                CompanyGuid = company1.Guid,
                Status = InviteStatusLevel.Accepted,
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

            _context.Set<Bank>().AddRange(new List<Bank> { bri, mandiri , bsi, bni, bca });

            _context.SaveChanges();

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
        }

    }
}

