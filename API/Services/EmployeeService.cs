using API.Contracts;
using API.Data;
using API.DTOs.Companies;
using API.DTOs.Employees;
using API.Models;
using API.Utilities.Enums;
using API.Utilities.Handlers;
using API.Utilities.Validations;
using ClosedXML.Excel;
using System.Security.Claims;

namespace API.Services;

public class EmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IAccountRoleRepository _accountRoleRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly TwizDbContext _twizDbContext;

    public EmployeeService(IEmployeeRepository employeeRepository, IAccountRepository accountRepository, ICompanyRepository companyRepository, IAccountRoleRepository accountRoleRepository, IRoleRepository roleRepository, TwizDbContext twizDbContext, IHttpContextAccessor httpContextAccessor)
    {
        _employeeRepository = employeeRepository;
        _accountRepository = accountRepository;
        _companyRepository = companyRepository;
        _roleRepository = roleRepository;
        _accountRoleRepository = accountRoleRepository;
        _twizDbContext = twizDbContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public IEnumerable<GetMasterEmployeeDto>? GetEmployees()
    {
        var employees = _employeeRepository.GetAll();
        if (employees is null)
        {
            return null; // No Employee Found
        }

        var companies = _companyRepository.GetAll();
        var accounts = _accountRepository.GetAll();

        var toDto = employees.Select(e =>
        {
            var account = accounts.FirstOrDefault(acc => acc.Guid == e.AccountGuid);
            var company = companies.FirstOrDefault(c => c.Guid == e.CompanyGuid);
            return new GetMasterEmployeeDto
            {
                Guid = e.Guid,
                Nik = e.Nik,
                FullName = e.FullName,
                Gender = e.Gender == GenderEnum.Male ? "male" : "female",
                BirthDate = e.BirthDate.ToString("dd/MM/yyyy"),
                HiringDate = e.HiringDate.ToString("dd/MM/yyyy"),
                PhoneNumber = e.PhoneNumber,
                CompanyName = company?.Name ?? "",
                Email = account?.Email ?? "",
            };
        }).OrderBy(e => e.FullName).ToList();

        var claimUser = _httpContextAccessor.HttpContext?.User;

        var userRole = claimUser?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        var accountGuid = claimUser?.Claims?.FirstOrDefault(x => x.Type == "Guid")?.Value;

        if (accountGuid == null)
        {
            return null;
        }

        if (userRole == nameof(RoleLevel.Company))
        {
            var company = companies.FirstOrDefault(c => c.AccountGuid == Guid.Parse(accountGuid));

            if (company is null)
            {
                return null;
            }

            toDto = toDto.Where(e => e.CompanyName == company.Name).ToList();
            return toDto;
        }
        else if (userRole == nameof(RoleLevel.SysAdmin))
        {
            return toDto;
        }
        else
        {
            return null;
        }
    }

    public IEnumerable<GetMasterEmployeeDto>? GetByCompany(Guid guid)
    {
        var employees = _employeeRepository.GetAll();
        if (employees is null)
        {
            return null; // No Employee Found
        }

        var companies = _companyRepository.GetAll();
        var accounts = _accountRepository.GetAll();

        var toDto = employees.Select(e =>
        {
            e.CompanyGuid = guid;
            var account = accounts.FirstOrDefault(acc => acc.Guid == e.AccountGuid);
            var company = companies.FirstOrDefault(c => c.Guid == e.CompanyGuid);
            return new GetMasterEmployeeDto
            {
                Guid = e.Guid,
                Nik = e.Nik,
                FullName = e.FullName,
                Gender = e.Gender == GenderEnum.Male ? "male" : "female",
                BirthDate = e.BirthDate.ToString("dd-MM-yyyy"),
                HiringDate = e.HiringDate.ToString("dd-MM-yyyy"),
                PhoneNumber = e.PhoneNumber,
                CompanyName = company?.Name ?? "",
                Email = account?.Email ?? "",
            };
        }).OrderBy(e => e.FullName).ToList();

        var claimUser = _httpContextAccessor.HttpContext?.User;

        var userRole = claimUser?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        var accountGuid = claimUser?.Claims?.FirstOrDefault(x => x.Type == "Guid")?.Value;

        if (accountGuid == null)
        {
            return null;
        }

        if (userRole == nameof(RoleLevel.Company))
        {
            var company = companies.FirstOrDefault(c => c.AccountGuid == Guid.Parse(accountGuid));

            if (company is null)
            {
                return null;
            }

            toDto = toDto.Where(e => e.CompanyName == company.Name).ToList();
            return toDto;
        }
        else if (userRole == nameof(RoleLevel.SysAdmin))
        {
            return toDto;
        }
        else
        {
            return null;
        }
    }

    public GetMasterEmployeeDto? GetEmployee(Guid guid)
    {
        var employee = _employeeRepository.GetByGuid(guid);
        if (employee is null)
        {
            return null;
        }

        var account = _accountRepository.GetAll().FirstOrDefault(acc => acc.Guid == employee.AccountGuid);
        var company = _companyRepository.GetAll().FirstOrDefault(c => c.Guid == employee.CompanyGuid);


        var toDto = new GetMasterEmployeeDto
        {
            Guid = employee.Guid,
            Nik = employee.Nik,
            FullName = employee.FullName,
            Gender = employee.Gender == GenderEnum.Male ? "male" : "female",
            BirthDate = employee.BirthDate.ToString("dd/MM/yyyy"),
            HiringDate = employee.HiringDate.ToString("dd/MM/yyyy"),
            PhoneNumber = employee.PhoneNumber,
            CompanyName = company?.Name ?? "",
            Email = account?.Email ?? "",
        };

        var claimUser = _httpContextAccessor.HttpContext?.User;

        var userRole = claimUser?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        var accountGuid = claimUser?.Claims?.FirstOrDefault(x => x.Type == "Guid")?.Value;

        if (accountGuid == null)
        {
            return null;
        }

        if (userRole == nameof(RoleLevel.Company))
        {
            var companySigned = _companyRepository.GetAll().FirstOrDefault(c => c.AccountGuid == Guid.Parse(accountGuid));

            if (companySigned is null)
            {
                return null;
            }

            if (companySigned.Guid != company!.Guid)
            {
                return null;
            }


            return toDto;
        }
        else if (userRole == nameof(RoleLevel.Employee))
        {
            var employeeSigned = _companyRepository.GetAll().FirstOrDefault(e => e.AccountGuid == Guid.Parse(accountGuid));

            if (employeeSigned is null)
            {
                return null;
            }

            if (employeeSigned.Guid != toDto.Guid)
            {
                return null;
            }

            return toDto;
        }
        else if (userRole == nameof(RoleLevel.SysAdmin))
        {
            return toDto;
        }
        else
        {
            return null;
        }

    }

    public GetMasterEmployeeDto? CreateEmployee(CreateEmployeeDto newEmployeeDto)
    {
        var claimUser = _httpContextAccessor.HttpContext?.User;

        var userRole = claimUser?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        var accountGuid = claimUser?.Claims?.FirstOrDefault(x => x.Type == "Guid")?.Value;

        if (accountGuid == null)
        {
            return null;
        }
        var transaction = _twizDbContext.Database.BeginTransaction();
        var account = new Account()
        {
            Guid = new Guid(),
            Email = newEmployeeDto.Email,
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
            transaction.Rollback();
            // gagal insert data 
            return null;
        }

        var employeeRole = _roleRepository.GetByName(nameof(RoleLevel.Employee));

        if (employeeRole is null)
        {
            transaction.Rollback();
            return null;
        }

        var accountRole = new AccountRole()
        {
            Guid = new Guid(),
            AccountGuid = createdAccount.Guid,
            RoleGuid = employeeRole.Guid,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };

        var createdAccountRole = _accountRoleRepository.Create(accountRole);

        if (createdAccountRole is null)
        {
            transaction.Rollback();
            // gagal insert data 
            return null;
        }

        if (userRole == nameof(RoleLevel.Company))
        {
            var company = _companyRepository.GetAll().FirstOrDefault(c => c.AccountGuid == Guid.Parse(accountGuid));

            if (company is null)
            {
                transaction.Rollback();
                return null;
            }

            var employee = new Employee
            {
                Guid = new Guid(),
                Nik = newEmployeeDto.Nik,
                FullName = newEmployeeDto.FullName,
                BirthDate = newEmployeeDto.BirthDate,
                Gender = newEmployeeDto.Gender.ToLower() == "male" ? GenderEnum.Male : GenderEnum.Female,
                HiringDate = newEmployeeDto.HiringDate,
                PhoneNumber = newEmployeeDto.PhoneNumber,
                AccountGuid = createdAccount.Guid,
                CompanyGuid = company.Guid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            var createdEmployee = _employeeRepository.Create(employee);
            if (createdEmployee is null)
            {
                transaction.Rollback();
                return null; // Employee Not Created
            }

            var toDto = new GetMasterEmployeeDto
            {
                Guid = createdEmployee.Guid,
                Nik = createdEmployee.Nik,
                FullName = createdEmployee.FullName,
                BirthDate = createdEmployee.BirthDate.ToString("dd MMMM yyyy, HH:mm WIB"),
                Gender = createdEmployee.Gender == GenderEnum.Male ? "male" : "female",
                HiringDate = createdEmployee.HiringDate.ToString("dd MMMM yyyy, HH:mm WIB"),
                PhoneNumber = createdEmployee.PhoneNumber,
                Email = newEmployeeDto.Email,
                CompanyName = company.Name,
            };
            transaction.Commit();
            return toDto; // Employee Created
        }
        else
        {
            return null;
        }

    }

    public int UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
    {
        var claimUser = _httpContextAccessor.HttpContext?.User;

        var userRole = claimUser?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        var accountGuid = claimUser?.Claims?.FirstOrDefault(x => x.Type == "Guid")?.Value;

        if (accountGuid == null)
        {
            return -2;
        }

        var getEmployee = _employeeRepository.GetByGuid(updateEmployeeDto.Guid);

        if (getEmployee is null)
        {
            return -1;
        }

        getEmployee.Nik = updateEmployeeDto.Nik;
        getEmployee.FullName = updateEmployeeDto.FullName;
        getEmployee.BirthDate = updateEmployeeDto.BirthDate;
        getEmployee.HiringDate = updateEmployeeDto.HiringDate;
        getEmployee.Gender = updateEmployeeDto.Gender.ToLower() == "male" ? GenderEnum.Male : GenderEnum.Female;
        getEmployee.PhoneNumber = updateEmployeeDto.PhoneNumber;
        getEmployee.ModifiedDate = DateTime.Now;

        if (userRole == nameof(RoleLevel.Company))
        {
            var company = _companyRepository.GetAll().FirstOrDefault(c => c.AccountGuid == Guid.Parse(accountGuid));

            if (company is null || company.Guid != getEmployee.CompanyGuid)
            {
                return -2;
            }
        }
        else if (userRole == nameof(RoleLevel.SysAdmin)) { }
        else
        {
            return -2;
        }

        var isUpdated = _employeeRepository.Update(getEmployee);
        if (!isUpdated)
        {
            return 0; // Employee Not Updated
        }
        return 1;
    }


    public int DeleteEmployee(Guid guid)
    {
        var employee = _employeeRepository.GetByGuid(guid);

        if (employee is null)
        {
            return -1;
        }

        var isDelete = _employeeRepository.Delete(employee);
        if (!isDelete)
        {
            return 0; // Employee Not Deleted
        }

        return 1; // Employee Deleted
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
            FileHandler.DeleteFileIfExist(filePath);
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
