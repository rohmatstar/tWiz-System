using Client.Contracts;
using Client.DTOs;
using Client.DTOs.Auths;
using Client.Models;
using Client.Utilities.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Client.Controllers
{
    public class AuthController : Controller
    {

        private readonly ICompanyRepository _companyRepository;
        private readonly IAuthRepository _authRepository;
        private readonly IPaymentRepository _paymentRepository;

        public AuthController(ICompanyRepository companyRepository, IAuthRepository authRepository, IPaymentRepository paymentRepository)
        {
            _companyRepository = companyRepository;
            _authRepository = authRepository;
            _paymentRepository = paymentRepository;
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

            TempData["type"] = RoleLevel.Company.ToString();
            return View("SignIn");
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgetPassword(ForgotPasswordDto forgotPasswordDto)
        {
            var result = await _authRepository.ForgetPassword(forgotPasswordDto);
            if (result.Code == 200)
            {
                
                TempData["email"] = result.Data.Email;
                TempData["role"] = result.Data.Role;
                return RedirectToAction("ResetPassword");
            }
            else
            {
                TempData["toast"] = new ToastDto
                {
                    Color = "danger",
                    Title = "Failed to Send OTP",
                    Subtitle = "So sorry, there is some mistake when sent otp to your email"
                };

                return View();
            }
        }

        [HttpGet]
        public IActionResult ResetPassword()
        {
            if (TempData["email"] != null)
            {
                TempData["toast"] = new ToastDto
                {
                    Color = "success",
                    Title = "OTP Sent!",
                    Subtitle = "Reset your password by filling this form below"
                };
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ChangePasswordDto changePasswordDto)
        {
            var type = Request.Form["type"].ToString();

            var result = await _authRepository.ResetPassword(changePasswordDto);
            if (result.Code == 200)
            {
                TempData["toast"] = new ToastDto
                {
                    Color = "success",
                    Title = "Password Changed!",
                    Subtitle = "Sign in with your new password"
                };

                if (type == RoleLevel.Company.ToString())
                {
                    TempData["type"] = RoleLevel.Company.ToString();
                    return View("SignIn");
                }
                else
                {
                    TempData["type"] = RoleLevel.Employee.ToString();
                    return View("SignIn");
                }
            }
            else
            {
                TempData["toast"] = new ToastDto
                {
                    Color = "danger",
                    Title = "Failed to Send OTP",
                    Subtitle = "So sorry, there is some mistake when sent otp to your email"
                };

                return View();
            }
        }

        /* ===== Company =======*/

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            var result = await _authRepository.SignUp(signUpDto);
            if (result.Code == 200)
            {
                TempData["toast"] = new ToastDto
                {
                    Color = "success",
                    Title = "Successfully sign up!",
                    Subtitle = "Your account has been created, pay to activate it"
                };

                TempData["type"] = RoleLevel.Company.ToString();
                return View("SignIn");
            }
            else
            {
                TempData["toast"] = new ToastDto
                {
                    Color = "danger",
                    Title = "Sign up Failed",
                    Subtitle = "So sorry, there is some mistake when signing up process"
                };

                return View();
            }
        }

        [HttpGet]
        public IActionResult SignInAsCompany()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            TempData["type"] = RoleLevel.Company.ToString();
            return View("SignIn");
        }

        /* SysAdmin*/
        [HttpGet]
        public IActionResult SysAdmin()
        {
            TempData["type"] = RoleLevel.SysAdmin.ToString();
            return View("SignIn");
        }
        public IActionResult SignoutSysAdmin()
        {
            HttpContext.Session.Remove("JWTToken");
            return Redirect("/Auth/SysAdmin");
        }

        /* General Sign In*/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            var type = Request.Form["type"].ToString();

            var result = await _authRepository.SignIn(signInDto);
            if (result.Code == 200)
            {
                // Role match checking
                var token = result?.Data;
                var jwtHandler = new JwtSecurityTokenHandler();
                var jwtToken = jwtHandler.ReadJwtToken(token);

                var roles = jwtToken.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
                string role = roles!.FirstOrDefault()!;

                if (type == role)
                {
                    HttpContext.Session.SetString("JWTToken", token!);

                    if (role == RoleLevel.Employee.ToString())
                    {
                        return RedirectToAction("Invited", "Event");
                    }

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    TempData["toast"] = new ToastDto
                    {
                        Color = "warning",
                        Title = "Credential Doesn't Match",
                        Subtitle = "Oops! you cannot sign in as " + type
                    };

                    TempData["type"] = type;
                    return View("SignIn");
                }
            }
            else if (result.Code == 402)
            {
                return RedirectToAction("PaymentRequired", "Payment", new { email = signInDto.Email });
            }
            else if (result.Code == 406)
            {
                TempData["toast"] = new ToastDto
                {
                    Color = "danger",
                    Title = "Account Deactivated",
                    Subtitle = "Your Account Temporarily Unavailable. Try Again Later!"
                };

                TempData["type"] = type;
                return View("SignIn");
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
        [HttpGet]
        public IActionResult SignInAsEmployee()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            TempData["type"] = RoleLevel.Employee.ToString();
            return View("SignIn");
        }
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