using Client.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class AuthController : Controller
{
    private readonly IAuthRepository _authRepository;

    public AuthController(IAuthRepository repository)
    {
        _authRepository = repository;
    }
    public IActionResult SignUp()
    {
        return View();
    }

    //[HttpPost]
    //public async Task<IActionResult> SignUp(SignUpDto signUpDto)
    //{
    //    var response = await _authRepository.SignUp(signUpDto);

    //    if (response.Code == "201")
    //    {
    //        TempData["Success"] = "Succesfully created your account!";
    //        return Redirect("Company/Login");
    //    }

    //    TempData["Error"] = response.Message;
    //    return RedirectToAction(nameof(SignUp));
    //}
}

