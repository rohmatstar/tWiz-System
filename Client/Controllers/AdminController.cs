using Client.Models;
using API.DTOs.Events;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using API.DTOs.Auths;
using Client.Contracts;

namespace Client.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAuthRepository repository;
        private readonly IEventRepository _eventRepository;

        public AdminController(IAuthRepository repository, IEventRepository eventRepository)
        {
            this.repository = repository;
            _eventRepository = eventRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Events()
        {
            var result = await _eventRepository.Get();
            var events = new List<EventsDto>();

            if (result.Data != null)
            {
                events = result.Data.Select(e => new EventsDto
                {
                    Guid = e.Guid,
                    Name = e.Name,
                    Thumbnail = e.Thumbnail,
                    Description = e.Description,
                    IsPublished = e.IsPublished,
                    IsPaid = e.IsPaid,
                    Price = e.Price,
                    Category = e.Category,
                    Status = e.Status,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    Quota = e.Quota,
                    Place = e.Place,
                    CreatedBy = e.CreatedBy
                    //IsActive = e.IsActive
                }).ToList();
            }

            return View(events);
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await repository.Login(loginDto);
            if (result.Code == 200)
            {
                HttpContext.Session.SetString("JWTToken", result.Data);
                return RedirectToAction("Index", "Admin");
            }
            return View();


        }

        [HttpGet("/Sign-Out")]
        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return Redirect("/Admin/Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {

            var result = await repository.Register(registerDto);
            if (result.Code == 200)
            {
                // TempData["Success"] = $"Successfully Registered! - {result.Message}!";
                return RedirectToAction("Login", "Admin");
            }
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

        public IActionResult SetSession(string JwtToken)
        {
            HttpContext.Session.SetString("JWTToken", JwtToken);
            return RedirectToAction("Index", "Admin");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}