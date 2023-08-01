using Client.Contracts;
using Client.DTOs;
using Client.DTOs.Auths;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class CompanyController : Controller
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IAuthRepository _authRepository;

    public CompanyController(ICompanyRepository companyRepository, IAuthRepository authRepository)
    {
        _companyRepository = companyRepository;
        _authRepository = authRepository;
    }

    
}

