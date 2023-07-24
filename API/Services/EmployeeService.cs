using API.Contracts;
using API.DTOs.Employees;
using API.Models;
using API.Repositories;

namespace API.Services;

public class EmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public IEnumerable<GetEmployeeDto> GetEmployees()
    {
        var employees = _employeeRepository.GetAll();
        if (!employees.Any())
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
}
