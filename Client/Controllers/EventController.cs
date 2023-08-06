using Client.Contracts;
using Client.DTOs.Events;
using Client.Models;
using Client.Utilities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;

namespace Client.Controllers;

[Authorize(Roles = $"{nameof(RoleLevel.Company)}, {nameof(RoleLevel.SysAdmin)}, {nameof(RoleLevel.Employee)}")]
public class EventController : Controller
{

    private readonly IEventRepository _eventRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public EventController(IEventRepository eventRepository, ICompanyRepository companyRepository, IEmployeeRepository employeeRepository)
    {
        _eventRepository = eventRepository;
        _companyRepository = companyRepository;
        _employeeRepository = employeeRepository;
    }

    // event controls
    public IActionResult Index([FromQuery] QueryParamGetEventDto queryForms)
    {
        var active = "event";
        ViewBag.Active = active;

        var token = HttpContext?.Session.GetString("JWTToken") ?? "";
        ViewData["token"] = token;

        var events = _eventRepository.GetInternal(queryForms);
        var companies = _companyRepository.Get();
        var employees = _employeeRepository.Get();

        string eventsJson = JsonSerializer.Serialize(events.Result);
        string companiesJson = JsonSerializer.Serialize(companies.Result);
        string employeesJson = JsonSerializer.Serialize(employees.Result);
        ViewData["eventsJson"] = eventsJson;
        ViewData["companiesJson"] = companiesJson;
        ViewData["employeesJson"] = employeesJson;

        return View(events.Result.Data);
    }

    [Authorize(Roles = $"{nameof(RoleLevel.Company)}, {nameof(RoleLevel.SysAdmin)}")]
    public IActionResult Create()
    {
        var active = "create_event";
        ViewBag.Active = active;

        var token = HttpContext?.Session.GetString("JWTToken") ?? "";
        ViewData["token"] = token;

        return View();
    }
    [Authorize(Roles = $"{nameof(RoleLevel.Company)}, {nameof(RoleLevel.SysAdmin)}")]
    [HttpGet("Edit/{guid}")]
    public async Task<IActionResult> Edit(Guid guid)
    {
        var active = "event";
        ViewBag.Active = active;

        var token = HttpContext?.Session.GetString("JWTToken") ?? "";
        ViewData["token"] = token;

        var response = await _eventRepository.GetEvent(guid);

        var singleEvent = new GetEventDto();

        if (response != null)
        {
            singleEvent = response.Data;

            string format = "dd MMMM yyyy, HH:mm 'WIB'";
            string outputFormat = "yyyy-MM-ddTHH:mm";
            var startDateTimeLocal = DateTime.ParseExact(singleEvent.StartDate, format, CultureInfo.InvariantCulture);
            var endDateTimeLocal = DateTime.ParseExact(singleEvent.EndDate, format, CultureInfo.InvariantCulture);

            singleEvent.StartDate = startDateTimeLocal.ToString(outputFormat);
            singleEvent.EndDate = endDateTimeLocal.ToString(outputFormat);

        }


        return View(singleEvent);
    }

    [HttpGet("participants")]
    public async Task<IActionResult> Participants(Guid eventGuid)
    {

        var participantsEvent = new GetParticipantsEventDto();

        var getParticipantsEvent = await _eventRepository.GetParticipantsEvent(eventGuid);

        if (getParticipantsEvent.Data != null)
        {
            participantsEvent = getParticipantsEvent.Data;
        }

        return View(participantsEvent);
    }

    /*[Authorize]*/
    // invitation events
    public IActionResult Invited([FromQuery] QueryParamGetEventDto queryParams)
    {
        var active = "invited_event";
        ViewBag.Active = active;

        var token = HttpContext?.Session.GetString("JWTToken") ?? "";
        ViewData["token"] = token;

        var events = _eventRepository.GetInvitationEvents(queryParams);
        var employees = _employeeRepository.Get();


        string eventsJson = JsonSerializer.Serialize(events.Result);
        string employeesJson = JsonSerializer.Serialize(employees.Result);



        ViewData["eventsJson"] = eventsJson;
        ViewData["employeesJson"] = employeesJson;

        return View(events.Result.Data);
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
