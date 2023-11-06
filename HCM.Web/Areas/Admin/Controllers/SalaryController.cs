namespace HCM.Web.Areas.Admin.Controllers;

using Models;
using Responses;
using Services.Contracts;
using Microsoft.AspNetCore.Mvc;

using MapsterMapper;

public class SalaryController : Controller
{
    private readonly IMapper _mapper;
    private readonly IEmployeeService _employeeService;

    public SalaryController(IMapper mapper, IEmployeeService employeeService)
    {
        _mapper = mapper;
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var apiResponse = await _employeeService.GetSalaries();
        var response = await ResponseParser.SalariesResponse(apiResponse);

        var salaries = new List<SalaryModel>();

        foreach (var town in response.Payload)
        {
            salaries.Add(_mapper.Map<SalaryModel>(town));
        }

        return View(salaries);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(SalaryCreateModel model)
    {
        var apiResponse = await _employeeService.CreateSalary(model);

        if (!apiResponse.IsSuccessStatusCode)
        {
            var errorMessages = await ResponseParser.ErrorResponse(apiResponse);

            foreach (var errorMessage in errorMessages)
            {
                ModelState.AddModelError(string.Empty, errorMessage);
            }

            return View();
        }

        TempData["SuccessMessage"] = "Salary was created successfully.";

        return RedirectToAction("Index", "Salary");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        var apiResponse = await _employeeService.GetSalary(id);
        var response = await ResponseParser.SalaryResponse(apiResponse);

        return View(_mapper.Map<SalaryModel>(response.Payload));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(SalaryModel model)
    {
        var apiResponse = await _employeeService.EditSalary(model);

        if (!apiResponse.IsSuccessStatusCode)
        {
            var errorMessages = await ResponseParser.ErrorResponse(apiResponse);

            foreach (var errorMessage in errorMessages)
            {
                ModelState.AddModelError(string.Empty, errorMessage);
            }

            return View();
        }

        TempData["SuccessMessage"] = "Salary was edited successfully.";

        return RedirectToAction("Index", "Salary");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(string id)
    {
        var apiResponse = await _employeeService.GetSalary(id);
        var response = await ResponseParser.SalaryResponse(apiResponse);

        return View(_mapper.Map<SalaryModel>(response.Payload));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteSalary(string id)
    {
        await _employeeService.DeleteSalary(id);

        TempData["SuccessMessage"] = "Salary was deleted successfully.";

        return RedirectToAction("Index", "Salary");
    }
}