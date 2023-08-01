using Client.DTOs;
using Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Client.Controllers
{
    public class EventController : Controller
    {
        private void SetCommonViewBagData()
        {
            ViewBag.Role = "company";
            ViewBag.Username = "PT Mitra Integrasi Informatika";
        }

        /*[Authorize]*/
        public IActionResult Index()
        {
            SetCommonViewBagData();
            var active = "event";
            ViewBag.Active = active;
            ViewBag.Toast = new ToastDto {
                Color = "danger",
                Title = "Changes Unsaved!",
                Subtitle = "There's some problem when save changes"
            };
            return View();
        }

        /*[Authorize]*/
        public IActionResult Create()
        {
            SetCommonViewBagData();
            var active = "create_event";
            ViewBag.Active = active;
            return View();
        }

        /*[Authorize]*/
        public IActionResult Invited()
        {
            SetCommonViewBagData();
            var active = "invited_event";
            ViewBag.Active = active;
            return View();
        }

        /*[Authorize]*/
        public IActionResult Ticket()
        {
            SetCommonViewBagData();
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