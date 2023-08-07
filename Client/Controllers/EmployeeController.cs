using Client.Contracts;
using Client.DTOs.Employees;
using Client.Utilities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

[Authorize(Roles = $"{nameof(RoleLevel.Company)}, {nameof(RoleLevel.SysAdmin)}")]
public class EmployeeController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IAuthRepository _authRepository;

    public EmployeeController(IEmployeeRepository employeeRepository, IAuthRepository authRepository)
    {
        _employeeRepository = employeeRepository;
        _authRepository = authRepository;
    }

    /* =========== View ============== */
    [HttpGet]
    public IActionResult Index()
    {
        var active = "employee";
        ViewBag.Active = active;
        return View();
    }

    [HttpGet]
    public IActionResult Import()
    {
        var active = "import_employee";
        ViewBag.Active = active;
        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        var active = "create_employee";
        ViewBag.Active = active;
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Update(Guid guid)
    {
        var active = "update_employee";
        ViewBag.Active = active;

        var result = await _employeeRepository.Get(guid);

        if (result.Data?.Guid is null)
        {
            return RedirectToAction(nameof(Index));
        }
        var employee = new GetMasterEmployeeDtoClient
        {
            Guid = result.Data.Guid,
            Nik = result.Data.Nik,
            FullName = result.Data.FullName,
            BirthDate = result.Data.BirthDate,
            Gender = result.Data.Gender,
            HiringDate = result.Data.HiringDate,
            PhoneNumber = result.Data.PhoneNumber,
            Email = result.Data.Email
        };



        return View(employee);
    }

}