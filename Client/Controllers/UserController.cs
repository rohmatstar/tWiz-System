using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class UserController : Controller
{
    public IActionResult Dashboard()
    {
        return View();
    }
}

