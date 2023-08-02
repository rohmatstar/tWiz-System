using API.Contracts;
using API.Data;
using API.DTOs.Companies;
using API.DTOs.Employees;
using API.Models;
using API.Utilities.Enums;
using API.Utilities.Handlers;
using API.Utilities.Validations;
using ClosedXML.Excel;

namespace API.Services;

public class EmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IAccountRoleRepository _accountRoleRepository;
    private readonly IRoleRepository _roleRepository;

    private readonly TwizDbContext _twizDbContext;

    public EmployeeService(IEmployeeRepository employeeRepository, IAccountRepository accountRepository, ICompanyRepository companyRepository, IAccountRoleRepository accountRoleRepository, IRoleRepository roleRepository, TwizDbContext twizDbContext)
    {
        _employeeRepository = employeeRepository;
        _accountRepository = accountRepository;
        _companyRepository = companyRepository;
        _roleRepository = roleRepository;
        _accountRoleRepository = accountRoleRepository;
        _twizDbContext = twizDbContext;
    }


    public IEnumerable<GetMasterEmployeeDto>? GetMasters()
    {
        var master = (from e in _employeeRepository.GetAll()
                      join acoount in _accountRepository.GetAll()
                      on e.AccountGuid equals acoount.Guid
                      join company in _companyRepository.GetAll()
                      on e.CompanyGuid equals company.Guid
                      join acc in _accountRepository.GetAll()
                      on company.AccountGuid equals acc.Guid

                      select new GetMasterEmployeeDto
                      {
                          Guid = e.Guid,
                          Nik = e.Nik,
                          FullName = e.FullName,
                          BirthDate = e.BirthDate,
                          Email = acoount.Email,
                          HiringDate = e.HiringDate,
                          Gender = e.Gender,
                          PhoneNumber = e.PhoneNumber,
                          CompanyName = company.Name,
                          CompanyEmail = acc.Email
                      }).ToList();

        if (master.Count == 0)
        {
            return null;
        }

        return master;
    }

    public GetMasterEmployeeDto? GetMasterByGuid(Guid guid)
    {
        var master = GetMasters();

        var masterByGuid = master.FirstOrDefault(master => master.Guid == guid);

        return masterByGuid;
    }

    public IEnumerable<GetEmployeeDto>? GetEmployees()
    {
        var employees = _employeeRepository.GetAll();
        if (employees is null)
        {
            return null; // No Employee Found
        }
        var toDto = employees.Select(employee => new GetEmployeeDto
        {
            Guid = employee.Guid,
            Nik = employee.Nik,
            FullName = employee.FullName,
            BirthDate = employee.BirthDate,
            Gender = employee.Gender,
            HiringDate = employee.HiringDate,
            PhoneNumber = employee.PhoneNumber,
            AccountGuid = employee.AccountGuid,
            CompanyGuid = employee.CompanyGuid

        }).ToList();

        return toDto;
    }

    public GetEmployeeDto? GetEmployee(Guid guid)
    {
        var employee = _employeeRepository.GetByGuid(guid);
        if (employee is null)
        {
            return null;
        }
        var toDto = new GetEmployeeDto
        {
            Guid = employee.Guid,
            Nik = employee.Nik,
            FullName = employee.FullName,
            BirthDate = employee.BirthDate,
            Gender = employee.Gender,
            HiringDate = employee.HiringDate,
            PhoneNumber = employee.PhoneNumber,
            AccountGuid = employee.AccountGuid,
            CompanyGuid = employee.CompanyGuid
        };
        return toDto;

    }

    public GetEmployeeDto? CreateEmployee(CreateEmployeeDto newEmployeeDto)
    {
        var employee = new Employee
        {
            Guid = new Guid(),
            Nik = newEmployeeDto.Nik,
            FullName = newEmployeeDto.FullName,
            BirthDate = newEmployeeDto.BirthDate,
            Gender = newEmployeeDto.Gender,
            HiringDate = newEmployeeDto.HiringDate,
            PhoneNumber = newEmployeeDto.PhoneNumber,
            AccountGuid = newEmployeeDto.AccountGuid,
            CompanyGuid = newEmployeeDto.CompanyGuid,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };

        var createdEmployee = _employeeRepository.Create(employee);
        if (createdEmployee is null)
        {
            return null; // Employee Not Created
        }

        var toDto = new GetEmployeeDto
        {
            Guid = createdEmployee.Guid,
            Nik = createdEmployee.Nik,
            FullName = createdEmployee.FullName,
            BirthDate = createdEmployee.BirthDate,
            Gender = createdEmployee.Gender,
            HiringDate = createdEmployee.HiringDate,
            PhoneNumber = createdEmployee.PhoneNumber,
            AccountGuid = createdEmployee.AccountGuid,
            CompanyGuid = createdEmployee.CompanyGuid
        };

        return toDto; // Employee Created
    }

    public int UpdateEmployee(UpdateEmployeeDto UpdateEmployeeDto)
    {
        var isExist = _employeeRepository.IsExist(UpdateEmployeeDto.Guid);
        if (!isExist)
        {
            return -1; // Employee Not Found
        }

        var getEmployee = _employeeRepository.GetByGuid(UpdateEmployeeDto.Guid);

        var employee = new Employee
        {
            Guid = UpdateEmployeeDto.Guid,
            Nik = UpdateEmployeeDto.Nik,
            FullName = UpdateEmployeeDto.FullName,
            BirthDate = UpdateEmployeeDto.BirthDate,
            Gender = UpdateEmployeeDto.Gender,
            HiringDate = UpdateEmployeeDto.HiringDate,
            PhoneNumber = UpdateEmployeeDto.PhoneNumber,
            AccountGuid = UpdateEmployeeDto.AccountGuid,
            CompanyGuid = UpdateEmployeeDto.CompanyGuid,
            ModifiedDate = DateTime.Now,
            CreatedDate = getEmployee!.CreatedDate
        };

        var isUpdate = _employeeRepository.Update(employee);
        if (!isUpdate)
        {
            return 0; // Employee Not Updated
        }
        return 1;
    }


    public int DeleteEmployee(Guid guid)
    {
        var isExist = _employeeRepository.IsExist(guid);
        if (!isExist)
        {
            return -1; // Employee Not Found
        }

        var employee = _employeeRepository.GetByGuid(guid);
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
