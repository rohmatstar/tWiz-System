using Client.Contracts;
using Client.DTOs;
using Client.DTOs.Auths;
using Client.DTOs.Companies;
using Client.Utilities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

[Authorize(Roles = $"{nameof(RoleLevel.Company)}, {nameof(RoleLevel.SysAdmin)}")]
public class CompanyController : Controller
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IAuthRepository _authRepository;

    public CompanyController(IAccountRepository accountRepository, ICompanyRepository companyRepository, IAuthRepository authRepository)
    {
        _companyRepository = companyRepository;
        _accountRepository = accountRepository;
        _authRepository = authRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var active = "company";
        ViewBag.Active = active;

        var company = await _companyRepository.GetCompany();
        var account = await _accountRepository.GetAccount();

        var mergedData = company.Data
        .Join(account.Data,
            companyData => companyData.AccountGuid,
            accountData => accountData.Guid,
            (companyData, accountData) => new GetCompanyMasterDto
            {
                Guid = companyData.Guid,
                Name = companyData.Name,
                PhoneNumber = companyData.PhoneNumber,
                Address = companyData.Address,
                Email = accountData.Email,
                IsActive = accountData.IsActive,
                AccountGuid = accountData.Guid
            })
        .ToList();

        return View(mergedData);
    }

    [HttpGet]
    public async Task<IActionResult> Deactivated()
    {
        var active = "deactivated_company";
        ViewBag.Active = active;

        var company = await _companyRepository.GetCompany();
        var account = await _accountRepository.GetAccount();

        var mergedData = company.Data
        .Join(account.Data,
            companyData => companyData.AccountGuid,
            accountData => accountData.Guid,
            (companyData, accountData) => new GetCompanyMasterDto
            {
                Guid = companyData.Guid,
                Name = companyData.Name,
                PhoneNumber = companyData.PhoneNumber,
                Address = companyData.Address,
                Email = accountData.Email,
                IsActive = accountData.IsActive,
                AccountGuid = accountData.Guid
            }).Where(data => data.IsActive == false)
        .ToList();

        return View(mergedData);
    }
}

