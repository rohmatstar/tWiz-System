using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class EventPaymentController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

