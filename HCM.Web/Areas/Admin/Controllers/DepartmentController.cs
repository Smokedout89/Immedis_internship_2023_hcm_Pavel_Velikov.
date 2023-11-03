namespace HCM.Web.Areas.Admin.Controllers;

using Models;
using Responses;
using MapsterMapper;
using Services.Contracts;
using Microsoft.AspNetCore.Mvc;

public class DepartmentController : Controller
{
    private readonly IMapper _mapper;
    private readonly IEmployeeService _employeeService;

    public DepartmentController(IMapper mapper, IEmployeeService employeeService)
    {
        _mapper = mapper;
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var apiResponse = await _employeeService.GetDepartments();
        var response = await ResponseParser.DepartmentResponse(apiResponse);

        var departments = new List<DepartmentModel>();

        foreach (var department in response.Payload)
        {
            departments.Add(_mapper.Map<DepartmentModel>(department));
        }

        return View(departments);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(DepartmentModel model)
    {
        var apiResponse = await _employeeService.CreateDepartment(model);

        if (!apiResponse.IsSuccessStatusCode)
        {
            var errorMessages = await ResponseParser.ErrorResponse(apiResponse);

            foreach (var errorMessage in errorMessages)
            {
                ModelState.AddModelError(string.Empty, errorMessage);
            }

            return View();
        }

        TempData["SuccessMessage"] = "Department was created successfully.";

        return RedirectToAction("Index", "Department");
    }
}