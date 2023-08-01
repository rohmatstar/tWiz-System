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

    [HttpGet]
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(SignInDto signDto)
    {

        var result = await _authRepository.SignIn(signDto);
        if (result.Code == 200)
        {
            var token = result?.Data;

            ViewBag.Toast = new ToastDto
            {
                Color = "success",
                Title = "Signed in",
                Subtitle = "Welcome, you have signed in to tWiz!"
            };

            HttpContext.Session.SetString("JWToken", token!);
            return RedirectToAction("Index", "Dashboard");
        }

        ViewBag.Toast = new ToastDto
        {
            Color = "danger",
            Title = "Sign in Failed",
            Subtitle = "So sorry, there is some mistake when signing in you"
        };
        return View();
    }
}

