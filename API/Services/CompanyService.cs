﻿using API.Contracts;
using API.Data;
using API.DTOs.Companies;
using API.Models;
using API.Utilities.Enums;
using System.Security.Claims;

namespace API.Services;

public class CompanyService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IAccountRoleRepository _accountRoleRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly TwizDbContext _twizDbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CompanyService(IEmployeeRepository employeeRepository, ICompanyRepository companyRepository, IAccountRepository accountRepository, IAccountRoleRepository accountRoleRepository, IRoleRepository roleRepository, TwizDbContext twizDbContext, IHttpContextAccessor httpContextAccessor)
    {
        _employeeRepository = employeeRepository;
        _companyRepository = companyRepository;
        _accountRepository = accountRepository;
        _accountRoleRepository = accountRoleRepository;
        _roleRepository = roleRepository;
        _twizDbContext = twizDbContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public IEnumerable<GetCompanyDto>? GetCompanies()
    {
        var companies = _companyRepository.GetAll();
        if (companies is null)
        {
            return null;
        }

        var claimUser = _httpContextAccessor.HttpContext?.User;

        var userRole = claimUser?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        var accountGuid = claimUser?.Claims?.FirstOrDefault(x => x.Type == "Guid")?.Value;

        if (accountGuid is null)
        {
            return null;
        }

        if (userRole == nameof(RoleLevel.Company))
        {
            var company = _companyRepository.GetAll().FirstOrDefault(c => c.AccountGuid == Guid.Parse(accountGuid));

            if (company is null)
            {
                return null;
            }

            companies = companies.Where(c => c.Guid != company.Guid).ToList();
        }


        var toDto = companies.Select(company => new GetCompanyDto
        {
            Guid = company.Guid,
            Name = company.Name,
            PhoneNumber = company.PhoneNumber,
            Address = company.Address,
            AccountGuid = company.AccountGuid,
        }).OrderBy(c => c.Name).ToList();

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


}
