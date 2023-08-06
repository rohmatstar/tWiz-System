using Client.Contracts;
using Client.DTOs;
using Client.DTOs.Auths;
using Client.DTOs.Employees;
using Client.Models;
using Client.Repositories;
using Client.Utilities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Diagnostics;

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

    /* =========== Crud ============== */
    /*public async Task<IActionResult> Index()
    {

        var result = await _employeeRepository.Get();
        var ListEmployee = new List<GetMasterEmployeeDtoClient>();

        if (result.Data != null)
        {
            ListEmployee = result.Data.ToList();
        }
        return View(ListEmployee);
    }*/

    /*[HttpPost]
    public async Task<IActionResult> Create(GetMasterEmployeeDto newEmployee)
    {
        var result = await _employeeRepository.Post(newEmployee);
        if (result.Code == 200)
        {
            TempData["Success"] = "Data berhasil masuk";
            return RedirectToAction(nameof(Index));
        }
        else if (result.Code == 409)
        {
            ModelState.AddModelError(string.Empty, result.Message);
            return View();
        }
        return RedirectToAction(nameof(Index));


    }*/

    /*[HttpPost]
    public async Task<IActionResult> Delete(Guid guid)
    {
        var result = await repository.Delete(guid);
*//*        var employee = new Employee();*//*
        if (result.Data?.Guid is null)
        {
            return RedirectToAction(nameof(Index));
        }
        else
        {
            employee.Guid = result.Data.Guid;
        }
        return RedirectToAction(nameof(Index));

    }*/

    /*[HttpGet]
    public async Task<IActionResult> Edit(Guid guid)
    {
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
            HiringDate = result.Data.HiringDate,
            PhoneNumber = result.Data.PhoneNumber,
*//*            CompanyGuid = result.Data.CompanyGuid,
            AccountGuid = result.Data.AccountGuid*//*
        };

        return View(employee);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(GetMasterEmployeeDto employee)
    {
        if (!ModelState.IsValid)
        {
            return View(employee);
        }
        var result = await _employeeRepository.Put(employee);
        if (result.Code == 200)
        {
            TempData["Success"] = "Data Berhasil Diubah";
        }
        else
        {
            TempData["Error"] = "Gagal mengubah data";
        }
        return RedirectToAction(nameof(Index));
    }*/
}