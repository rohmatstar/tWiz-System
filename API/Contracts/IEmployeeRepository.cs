﻿using API.Models;

namespace API.Contracts;

public interface IEmployeeRepository : IGeneralRepository<Employee>
{
    IEnumerable<Employee> GetByFirstName(string name);
    IEnumerable<Employee> GetByCompany(Guid guid);
    //IEnumerable<Employee> GetName(Guid fkAccountGuid);
}
