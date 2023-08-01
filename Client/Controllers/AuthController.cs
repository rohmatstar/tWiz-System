using Client.Contracts;
﻿using Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Client.Controllers
{
    private readonly IAuthRepository _authRepository;

    public class AuthController : Controller
    {
        public AuthController(IAuthRepository repository)
        {
            _authRepository = repository;
        }

        public IActionResult SignUp()
        {
            return View();
        }

        /*[Authorize]*/
        public IActionResult Login()
        {
            return View();
        }

        /*[Authorize]*/
        public IActionResult Register()
        {
            return View();
        }

        /*[Authorize]*/
        public IActionResult ForgetPassword()
        {
            return View();
        }

        /*[Authorize]*/
        public IActionResult ResetPassword()
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