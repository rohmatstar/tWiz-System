using Client.Contracts;
using Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Client.Controllers;

public class EventController : Controller
{

    private readonly IEventRepository _eventRepository;

    public EventController(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }
    public IActionResult Index()
    {
        var active = "event";
        ViewBag.Active = active;

        var token = HttpContext?.Session.GetString("JWTToken") ?? "";
        ViewData["token"] = token;

        var events = _eventRepository.Getall();
        Console.WriteLine(events.Result);

        return View(events.Result.Data);
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
