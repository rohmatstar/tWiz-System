using API.Contracts;
using API.Data;
using API.DTOs.Companies;
using API.Models;
using API.Utilities.Enums;
using API.Utilities.Handlers;
using API.Utilities.Validations;
using ClosedXML.Excel;

namespace API.Services;

public class CompanyService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IAccountRoleRepository _accountRoleRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly TwizDbContext _twizDbContext;

    public CompanyService(IEmployeeRepository employeeRepository, ICompanyRepository companyRepository, IAccountRepository accountRepository, IAccountRoleRepository accountRoleRepository, IRoleRepository roleRepository, TwizDbContext twizDbContext)
    {
        _employeeRepository = employeeRepository;
        _companyRepository = companyRepository;
        _accountRepository = accountRepository;
        _accountRoleRepository = accountRoleRepository;
        _roleRepository = roleRepository;
        _twizDbContext = twizDbContext;
    }

    public IEnumerable<GetCompanyDto>? GetCompanies()
    {
        var companies = _companyRepository.GetAll();
        if (companies is null)
        {
            return null;
        }
        var toDto = companies.Select(company => new GetCompanyDto
        {
            Guid = company.Guid,
            Name = company.Name,
            PhoneNumber = company.PhoneNumber,
            Address = company.Address,
            AccountGuid = company.AccountGuid,
        }).ToList();

        return toDto;
    }

    public GetCompanyDto? GetCompany(Guid guid)
    {
        var comapanies = _companyRepository.GetByGuid(guid);
        if (comapanies is null)
        {
            return null;
        }
        var toDto = new GetCompanyDto
        {
            Guid = comapanies.Guid,
            Name = comapanies.Name,
            PhoneNumber = comapanies.PhoneNumber,
            Address = comapanies.Address,
            AccountGuid = comapanies.AccountGuid,
        };
        return toDto;

    }

    public GetCompanyDto? CreateCompany(CreateCompanyDto newCompanyDto)
    {
        var companies = new Company
        {
            Guid = new Guid(),
            Name = newCompanyDto.Name,
            PhoneNumber = newCompanyDto.PhoneNumber,
            Address = newCompanyDto.Address,
            AccountGuid = newCompanyDto.AccountGuid,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };

        var createdCompanies = _companyRepository.Create(companies);
        if (createdCompanies is null)
        {
            return null; // Company Not Created
        }

        var toDto = new GetCompanyDto
        {
            Guid = createdCompanies.Guid,
            Name = createdCompanies.Name,
            PhoneNumber = createdCompanies.PhoneNumber,
            Address = createdCompanies.Address,
            AccountGuid = createdCompanies.AccountGuid

        };

        return toDto; // Company Created
    }

    public int UpdateCompany(UpdateCompanyDto UpdateCompanyDto)
    {
        var isExist = _companyRepository.IsExist(UpdateCompanyDto.Guid);
        if (!isExist)
        {
            return -1; // Company Not Found
        }

        var getCompany = _companyRepository.GetByGuid(UpdateCompanyDto.Guid);

        var company = new Company
        {
            Guid = UpdateCompanyDto.Guid,
            Name = UpdateCompanyDto.Name,
            PhoneNumber = UpdateCompanyDto.PhoneNumber,
            Address = UpdateCompanyDto.Address,
            AccountGuid = UpdateCompanyDto.AccountGuid,
            ModifiedDate = DateTime.Now,
            CreatedDate = getCompany!.CreatedDate
        };

        var isUpdate = _companyRepository.Update(company);
        if (!isUpdate)
        {
            return 0; // Company Not Updated
        }

        return 1;
    }


    public int DeleteCompany(Guid guid)
    {
        var isExist = _companyRepository.IsExist(guid);
        if (!isExist)
        {
            return -1; // Company Not Found
        }

        var company = _companyRepository.GetByGuid(guid);
        var isDelete = _companyRepository.Delete(company);
        if (!isDelete)
        {
            return 0; // Company Not Deleted
        }

        return 1; // Company Deleted
    }

    public async Task<int> ImportEmployees(ImportEmployeesDto importEmployeesDto)
    {
        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\tmp\excel");

        if (!Directory.Exists(folderPath))
        {
            try
            {
                Directory.CreateDirectory(folderPath);
            }
            catch (Exception ex)
            {
                // gagal membuat folder penyimpanan file excel
                return -1;
            }
        }

        var randomName = GenerateHandler.GenerateRandomString();
        var fileName = randomName + importEmployeesDto.File.FileName;
        var excelUrl = $"tmp/excel/{fileName}";
        var filePath = $"{folderPath}\\{fileName}";

        bool isExcel = FileValidation.IsValidExcelExtension(importEmployeesDto.File);

        if (!isExcel)
        {
            // file yang diupload bukan excel
            return -2;
        }

        try
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await importEmployeesDto.File.CopyToAsync(stream);
            }
        }
        catch
        {
            // gagal upload file excel
            return -3;
        }

        var employeeRoleGuid = _roleRepository.GetByName(nameof(RoleLevel.Employee))?.Guid;

        if (employeeRoleGuid == null)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            // data role name employee belum di buat
            return -4;
        }


        var employeeAccounts = new List<EmployeeAccountDto>();
        using (var workbook = new XLWorkbook(filePath))
        {
            var worksheet = workbook.Worksheet(1); // Ambil worksheet pertama

            var rows = worksheet.RowsUsed();

            // urutan column : No | Nik | FullName | BirthDate | Gender | HiringDate | PhoneNumber | Email  

            foreach (var row in rows.Skip(1)) // Lewati baris pertama karena itu adalah judul kolom
            {
                var employeeAccount = new EmployeeAccountDto()
                {
                    Nik = row.Cell(2).Value.ToString(),
                    FullName = row.Cell(3).Value.ToString(),
                    BirthDate = row.Cell(4).Value.ToString(),
                    Gender = row.Cell(5).Value.ToString(),
                    HiringDate = row.Cell(6).Value.ToString(),
                    PhoneNumber = row.Cell(7).Value.ToString(),
                    Email = row.Cell(8).Value.ToString(),
                };

                employeeAccounts.Add(employeeAccount);

            }
        }

        var transaction = _twizDbContext.Database.BeginTransaction();

        foreach (var employeeAccount in employeeAccounts)
        {
            var account = new Account()
            {
                Guid = new Guid(),
                Email = employeeAccount.Email,
                Password = HashingHandler.HashPassword("s4n64tr4h45i4"),
                IsActive = true,
                Token = null,
                TokenIsUsed = null,
                TokenExpiration = null,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };

            var createdAccount = _accountRepository.Create(account);

            if (createdAccount is null)
            {
                FileHandler.DeleteFileIfExist(filePath);
                transaction.Rollback();
                // gagal insert data 
                return -5;
            }

            var accountRole = new AccountRole()
            {
                Guid = new Guid(),
                AccountGuid = createdAccount.Guid,
                RoleGuid = (Guid)employeeRoleGuid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var createdAccountRole = _accountRoleRepository.Create(accountRole);

            if (createdAccountRole is null)
            {
                FileHandler.DeleteFileIfExist(filePath);
                transaction.Rollback();
                // gagal insert data 
                return -5;
            }

            var employee = new Employee()
            {
                Nik = employeeAccount.Nik,
                FullName = employeeAccount.FullName,
                Gender = employeeAccount.Gender.ToLower() == "female" ? GenderEnum.Female : GenderEnum.Male,
                BirthDate = DateTime.Parse(employeeAccount.BirthDate),
                HiringDate = DateTime.Parse(employeeAccount.HiringDate),
                PhoneNumber = employeeAccount.PhoneNumber,
                AccountGuid = createdAccount.Guid,
                CompanyGuid = importEmployeesDto.CompanyGuid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var createdEmployee = _employeeRepository.Create(employee);

            if (createdEmployee is null)
            {
                FileHandler.DeleteFileIfExist(filePath);
                transaction.Rollback();
                // gagal insert data 
                return -5;
            }

        }

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        transaction.Commit();


        return 1;
    }
}
