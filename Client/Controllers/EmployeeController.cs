using Client.Contracts;
using Client.DTOs;
using Client.DTOs.Employees;
using Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Diagnostics;

namespace Client.Controllers;


public class EmployeeController : Controller
{
    private readonly IEmployeeRepository repository;

    public EmployeeController(IEmployeeRepository repository)
    {
        this.repository = repository;
    }



    public async Task<IActionResult> Index()
    {

        var result = await repository.Get();
        var ListEmployee = new List<GetMasterEmployeeDtoClient>();

        if (result.Data != null)
        {
            ListEmployee = result.Data.ToList();
        }
        return View(ListEmployee);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(GetMasterEmployeeDtoClient newEmployee)
    {
        var result = await repository.Post(newEmployee);
        if (result.Status == "200")
        {
            TempData["Success"] = "Data berhasil masuk";
            return RedirectToAction(nameof(Index));
        }
        else if (result.Status == "409")
        {
            ModelState.AddModelError(string.Empty, result.Message);
            return View();
        }
        return RedirectToAction(nameof(Index));


    }

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

    [HttpGet]
    public async Task<IActionResult> Edit(Guid guid)
    {
        var result = await repository.Get(guid);

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
/*            CompanyGuid = result.Data.CompanyGuid,
            AccountGuid = result.Data.AccountGuid*/
        };

        return View(employee);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(GetMasterEmployeeDtoClient employee)
    {
        if (!ModelState.IsValid)
        {
            return View(employee);
        }
        var result = await repository.Put(employee.Guid, employee);
        if (result.Status == "200")
        {
            TempData["Success"] = "Data Berhasil Diubah";
        }
        else
        {
            TempData["Error"] = "Gagal mengubah data";
        }
        return RedirectToAction(nameof(Index));
    }
}