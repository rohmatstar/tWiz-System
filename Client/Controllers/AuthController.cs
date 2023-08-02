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

        /* ===== General =======*/
        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("SignIn", new { loginType = "Company" });
        }
        public IActionResult ForgetPassword()
        {
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        /* ===== Company =======*/
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignIn(string loginType)
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            if (loginType != null)
            {
                if (loginType == "Employee" || loginType == "Company")
                {
                    TempData["loginType"] = loginType;
                    return View();
                }
            }
            return RedirectToAction("SignIn", new { loginType = "Company" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompanySignIn(SignInDto signDto)
        {
            var result = await _authRepository.SignIn(signDto);
            if (result.Code == 200)
            {
                var token = result?.Data;
                HttpContext.Session.SetString("JWTToken", token!);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                TempData["toast"] = new ToastDto
                {
                    Color = "danger",
                    Title = "Sign in Failed",
                    Subtitle = "So sorry, there is some mistake when signing in you"
                };

                return View("SignIn");
            }
        }
        public IActionResult CompanySignOut()
        {
            HttpContext.Session.Remove("JWTToken");
            return RedirectToAction("CompanySignIn", "Auth");
        }

        /* ===== Employee =======*/
        [HttpGet]
        public IActionResult EmployeeSignIn()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Event");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EmployeeSignIn(SignInDto signDto)
        {
            var result = await _authRepository.SignIn(signDto);
            if (result.Code == 200)
            {
                var token = result?.Data;
                HttpContext.Session.SetString("JWTToken", token!);
                return RedirectToAction("Index", "Event");
            }
            else
            {
                TempData["toast"] = new ToastDto
                {
                    Color = "danger",
                    Title = "Sign in Failed",
                    Subtitle = "So sorry, there is some mistake when signing in you"
                };

                return View();
            }
        }
        public IActionResult EmployeeSignOut()
        {
            HttpContext.Session.Remove("JWTToken");
            return RedirectToAction("EmployeeSignIn", "Auth");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}