using Client.Contracts;
using Client.DTOs.EventPayments;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class EventPaymentController : Controller
{
    private readonly IEventPaymentRepository _eventPaymentRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public EventPaymentController(IEventPaymentRepository eventPaymentRepository)
    {
        _eventPaymentRepository = eventPaymentRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Index(Guid guid)
    {
        var eventPaymentSummary = new EventPaymentSummaryDto();
        var response = await _eventPaymentRepository.GetSummary(guid);

        if (response.Data != null)
        {
            eventPaymentSummary = response.Data;
        }

        TempData["payment"] = eventPaymentSummary;


        return View(eventPaymentSummary);
    }
}

