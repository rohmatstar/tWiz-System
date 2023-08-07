using Client.Contracts;
using Client.DTOs.EventPayments;
using Client.DTOs.Events;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class EventPaymentController : Controller
{
    private readonly IEventPaymentRepository _eventPaymentRepository;
    private readonly IEventRepository _eventRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public EventPaymentController(IEventPaymentRepository eventPaymentRepository, IEventRepository eventRepository)
    {
        _eventPaymentRepository = eventPaymentRepository;
        _eventRepository = eventRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Index(Guid guid)
    {
        var active = "invited_event";
        ViewBag.Active = active;

        var eventPaymentSummary = new EventPaymentSummaryDto();
        var response = await _eventPaymentRepository.GetSummary(guid);

        if (response.Data != null)
        {
            eventPaymentSummary = response.Data;
        }

        TempData["payment"] = eventPaymentSummary;


        return View(eventPaymentSummary);
    }

    [HttpGet]
    public async Task<IActionResult> PaidEvent(Guid guid)
    {
        var active = "event_payment";
        ViewBag.Active = active;

        var companyPaidEvents = new List<GetEventDto>();
        var response = await _eventRepository.GetPublishedPaidEvents();

        if (response.Data != null)
        {
            companyPaidEvents = response.Data;
        }

        //TempData["paid_events"] = companyPaidEvents;


        return View(companyPaidEvents);
    }

    [HttpGet]
    public async Task<IActionResult> ListParticipantsEvent(Guid eventGuid)
    {
        var active = "event_payment";
        ViewBag.Active = active;

        var paidEventParticipants = new GetParticipantsPaidEventDto();
        var response = await _eventPaymentRepository.GetParticipantsPaidEvent(eventGuid);

        if (response.Data != null)
        {
            paidEventParticipants = response.Data;
        }

        //TempData["paid_events"] = paidEventParticipants;


        return View(paidEventParticipants);
    }
}

