using Client.Contracts;
using Client.DTOs;
using Client.DTOs.Auths;
using Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Client.Controllers
{
    public class AuthController : Controller
    {

        private readonly ICompanyRepository _companyRepository;
        private readonly IAuthRepository _authRepository;

        public AuthController(ICompanyRepository companyRepository, IAuthRepository authRepository)
        {
            _companyRepository = companyRepository;
            _authRepository = authRepository;
        }

        /*[Authorize]*/
        [HttpGet]
        public IActionResult SignIn()
        {
            ViewBag.Toast = new ToastDto
            {
                Color = "success",
                Title = "Signed in",
                Subtitle = "Welcome, you have signed in to tWiz!"
            };
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

                HttpContext.Session.SetString("JWTToken", token!);
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

        /*[Authorize]*/
        public IActionResult ForgetPassword()
        {
            return View();
        }

        /*[Authorize]*/
        public IActionResult ResetPassword()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}