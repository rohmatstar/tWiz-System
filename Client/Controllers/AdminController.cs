using Client.Models;
/*using Client.DTOs.Events;*/
using Microsoft.AspNetCore.Authorization;
﻿using Client.Contracts;
using Client.DTOs.Employees;
using Client.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Diagnostics;
using Client.Contracts;
using Microsoft.AspNetCore.Authorization;
using Client.DTOs.Auths;

namespace Client.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAuthRepository repository;
        /*private readonly IEventRepository _eventRepository;*/

        public AdminController(IAuthRepository repository, IEmployeeRepository employeeRepository)
        {
            this.repository = repository;
            /*_eventRepository = eventRepository;*/
            this.employeeRepository = employeeRepository;
        }
        private readonly IEmployeeRepository employeeRepository;

        /*  [Authorize]
        public IActionResult IndexAuth()
        {
            return View();
        } */

        /*[Authorize]
        public async Task<IActionResult> Events()
        {
            var result = await _eventRepository.Get();
            var events = new List<EventsDto>();

            if (result.Data != null)
            if (HttpContext.Session.GetString("JWTToken") != null)
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
        }*/

        /*[Authorize]*/
        public IActionResult Index()/*async Task<IActionResult> Index()*/
        {
            /*var result = await employeeRepository.Get();
            var ListEmployee = new List<GetMasterEmployeeDtoClient>();
            
            if (result.Data != null)
            {
                ListEmployee = result.Data.ToList();
            }
            return View(ListEmployee);*/
            return View();
        }
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

        [HttpGet]
        public IActionResult CreateEvent()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEvent(EventsDto eventDto)
        {
            var result = await _eventRepository.Post(eventDto);
            if (result.Code == 200)
            {
                return RedirectToAction("Event", "Admin");
            }
            return View();


        }*/


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

        /*[HttpPost]
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}