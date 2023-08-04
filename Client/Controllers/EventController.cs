using Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Client.Controllers
{
    public class EventController : Controller
    {
        /*[Authorize]*/
        public IActionResult Index()
        {
            var active = "event";
            ViewBag.Active = active;

            return View();
        }

        /*[Authorize]*/
        public IActionResult Create()
        {
            var active = "create_event";
            ViewBag.Active = active;

            var token = HttpContext?.Session.GetString("JWTToken") ?? "";
            ViewData["token"] = token;

            return View();
        }

        /*[Authorize]*/
        public IActionResult Invited()
        {
            var active = "invited_event";
            ViewBag.Active = active;
            return View();
        }

        /*[Authorize]*/
        public IActionResult Ticket()
        {
            var active = "ticket";
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