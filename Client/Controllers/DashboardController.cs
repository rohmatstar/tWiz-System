using Client.DTOs;
using Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace Client.Controllers
{
    public class DashboardController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            var active = "dashboard";
            ViewBag.Active = active;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}