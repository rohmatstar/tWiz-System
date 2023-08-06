using Client.Contracts;
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
    public IActionResult Index()
    {
        return View();
    }
}

