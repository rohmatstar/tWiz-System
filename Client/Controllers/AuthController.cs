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
            return Redirect("/Auth/SignIn");
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            TempData["type"] = "Company";
            return View("SignIn");
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

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            
        }*/

        [HttpGet]
        public IActionResult SignInAsCompany()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            TempData["type"] = "Company";
            return View("SignIn");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInDto signDto)
        {
            var type = Request.Form["type"].ToString();

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

                TempData["type"] = type;
                return View("SignIn");
            }
        }

        public IActionResult SignoutCompany()
        {
            /*HttpContext.Session.Remove("JWTToken");
            TempData["toast"] = new ToastDto
            {
                Color = "success",
                Title = "Signed Out!",
                Subtitle = "You have been Logged out of System. Sign in to access it again"
            };

            TempData["type"] = "Company";
            return View("SignIn");*/

            HttpContext.Session.Remove("JWTToken");
            return Redirect("/Auth/SignInAsCompany");
        }

        /* ===== Employee =======*/
        public IActionResult SignoutEmployee()
        {
            HttpContext.Session.Remove("JWTToken");
            return Redirect("/Auth/SignInAsEmployee");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}