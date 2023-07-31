using Client.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class CompanyController : Controller
{
    private readonly ICompanyRepository _companyrepository;

    public CompanyController(ICompanyRepository companyRepository)
    {
        _companyrepository = companyRepository;
    }

    public IActionResult SignIn()
    {
        return View();
    }
}

