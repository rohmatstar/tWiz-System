using Client.Contracts;
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

    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(SignInDto signDto)
    {

        var result = await _authRepository.SignIn(signDto);
        if (result.Code == "200")
        {
            var token = result?.Data;

            TempData["Success"] = "Berhasil Login";
            //HttpContext.Session.SetString("JWToken", token);
            HttpContext.Session.SetString("JWToken", token!);
            return RedirectToRoute(new { controller = "User", action = "Dashboard" });
        }

        TempData["Error"] = result.Message;
        return View();
    }
}

