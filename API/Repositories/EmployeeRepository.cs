﻿using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class EmployeeRepository : GeneralRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(TwizDbContext context) : base(context)
    {
    }

    public IEnumerable<Employee> GetByFirstName(string name)
    {
        return _context.Set<Employee>().Where(employee => employee.FullName.Contains(name));
    }

    public IEnumerable<Employee> GetByCompany(Guid guid)
    {
        return _context.Set<Employee>().Where(employee => employee.CompanyGuid == guid).ToList();
    }

    //public IEnumerable<Employee> GetName(Guid fkAccountGuid)
    //{
    //    return _context.Set<Employee>().Where(employee => employee.AccountGuid == fkAccountGuid);
    //}

}
