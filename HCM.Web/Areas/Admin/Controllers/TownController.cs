namespace HCM.Web.Areas.Admin.Controllers;

using Models;
using Responses;
using MapsterMapper;
using Services.Contracts;
using Microsoft.AspNetCore.Mvc;

public class TownController : Controller
{
    private readonly IMapper _mapper;
    private readonly IEmployeeService _employeeService;

    public TownController(IMapper mapper, IEmployeeService employeeService)
    {
        _mapper = mapper;
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var apiResponse = await _employeeService.GetTowns();
        var response = await ResponseParser.TownsResponse(apiResponse);

        var towns = new List<TownModel>();

        foreach (var town in response.Payload)
        {
            towns.Add(_mapper.Map<TownModel>(town));
        }

        return View(towns);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(TownCreateModel model)
    {
        var apiResponse = await _employeeService.CreateTown(model);

        if (!apiResponse.IsSuccessStatusCode)
        {
            var errorMessages = await ResponseParser.ErrorResponse(apiResponse);

            foreach (var errorMessage in errorMessages)
            {
                ModelState.AddModelError(string.Empty, errorMessage);
            }

            return View();
        }

        TempData["SuccessMessage"] = "Town was created successfully.";

        return RedirectToAction("Index", "Town");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        var apiResponse = await _employeeService.GetTown(id);
        var response = await ResponseParser.TownResponse(apiResponse);

        return View(_mapper.Map<TownModel>(response.Payload));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(TownModel model)
    {
        var apiResponse = await _employeeService.EditTown(model);

        if (!apiResponse.IsSuccessStatusCode)
        {
            var errorMessages = await ResponseParser.ErrorResponse(apiResponse);

            foreach (var errorMessage in errorMessages)
            {
                ModelState.AddModelError(string.Empty, errorMessage);
            }

            return View();
        }

        TempData["SuccessMessage"] = "Town was edited successfully.";

        return RedirectToAction("Index", "Town");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(string id)
    {
        var apiResponse = await _employeeService.GetTown(id);
        var response = await ResponseParser.TownResponse(apiResponse);

        return View(_mapper.Map<TownModel>(response.Payload));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteTown(string id)
    {
        await _employeeService.DeleteTown(id);

        TempData["SuccessMessage"] = "Town was deleted successfully.";

        return RedirectToAction("Index", "Town");
    }
}