using Client.Contracts;
using Client.DTOs.Employees;
using Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Client.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAuthRepository repository;
        private readonly IEmployeeRepository employeeRepository;

        public AdminController(IAuthRepository repository, IEmployeeRepository employeeRepository)
        {
            this.repository = repository;
            this.employeeRepository = employeeRepository;
        }

        /*  [Authorize]
          public IActionResult IndexAuth()
          {
              if (HttpContext.Session.GetString("JWTToken") != null)
              {
                  string token = HttpContext.Session.GetString("JWTToken")!;
                  return View("Index", token);
              }

              return View("Login", "Admin");
          }

          [Authorize]*/
        public async Task<IActionResult> Index()
        {


            var result = await employeeRepository.Get();
            var ListEmployee = new List<GetMasterEmployeeDtoClient>();

            if (result.Data != null)
            {
                ListEmployee = result.Data.ToList();
            }
            return View(ListEmployee);



        }
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        /*  [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> Login(LoginDto loginDto)
          {
              var result = await repository.Login(loginDto);
              if (result.Code == "200")
              {
                  HttpContext.Session.SetString("JWTToken", result.Data);
                  return RedirectToAction("Index", "Admin");
              }
              return View();


          }*/

        /*public IActionResult Login()
        {
            return View();
        }*/

        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        public IActionResult ConfirmEmail()
        {
            return View();
        }

        public IActionResult SetSession(string JwtToken)
        {
            HttpContext.Session.SetString("JWTToken", JwtToken);
            return RedirectToAction("Index", "Admin");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("JWTToken");
            return RedirectToAction("Login", "Admin");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}