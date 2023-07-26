using API.DTOs.Employees;
using Client.Contracts;
using Client.DTOs;
using Client.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Diagnostics;

namespace Client.Controllers
{
    public class AdminController : Controller
    {
        private readonly IEmployeeRepository repository;

        public  AdminController(IEmployeeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> Index()
        {

            var result = await repository.Get();
            var ListEmployee = new List<GetMasterEmployeeDtoClient>();

            if (result.Data != null)
            {
                ListEmployee = result.Data.ToList();
            }
            Console.WriteLine("string TEST");
            Console.WriteLine(ListEmployee[0].CompanyName);
            return View(ListEmployee);
            
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

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

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}