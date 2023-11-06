namespace HCM.Web.Areas.User.Controllers;

using Models;
using Responses;
using MapsterMapper;
using Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Domain.Abstractions.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

public class EmployeeController : Controller
{
    private readonly IMapper _mapper;
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IMapper mapper, IEmployeeService employeeService)
    {
        _mapper = mapper;
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var apiResponse = await _employeeService.GetEmployees();
        var response = await ResponseParser.EmployeeResponse(apiResponse);

        var employees = response.Payload.Select(
            employee => _mapper.Map<EmployeeModel>(employee)).ToList();

        return View(employees);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var departments = await LoadDepartments();
        var towns = await LoadTowns();
        var salaries = await LoadSalaries();

        ViewBag.Departments = departments.Select(x =>
            new SelectListItem(x.Name, x.Id)).ToList();
        ViewBag.Towns = towns.Select(x =>
            new SelectListItem(x.Name, x.Id)).ToList();
        ViewBag.Salaries = salaries.Select(x =>
            new SelectListItem(x.GrossSalary.ToString(
                "c"), x.Id)).ToList();

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(EmployeeWithAllData model)
    {

        if (!ModelState.IsValid)
        {
            var departments = await LoadDepartments();
            var salaries = await LoadSalaries();

            ViewBag.Departments = departments.Select(x =>
                new SelectListItem(x.Name, x.Id)).ToList();
            ViewBag.Salaries = salaries.Select(x =>
                new SelectListItem(x.GrossSalary.ToString(
                    "c"), x.Id)).ToList();

            return View(model);
        }

        var gender = Enum.Parse<GenderType>(model.Gender);
        var contract = Enum.Parse<ContractType>(model.ContractType);
        var dob = DateOnly.Parse(model.DateOfBirth);
        var hd = DateOnly.Parse(model.HireDate);

        var employee = new EmployeeCreateModel
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Age = model.Age,
            JobTitle = model.JobTitle,
            Gender = gender,
            ContractType = contract,
            DateOfBirth = dob,
            HireDate = hd,
            DepartmentId = model.Department,
            AddressId = "fdfdac82-c7a6-4728-91d9-25c80037afa7",
            SalaryId = model.Salary
        };

        var apiResponse = await _employeeService.CreateEmployee(employee);

        if (!apiResponse.IsSuccessStatusCode)
        {
            var errorMessages = await ResponseParser.ErrorResponse(apiResponse);

            foreach (var errorMessage in errorMessages)
            {
                ModelState.AddModelError(string.Empty, errorMessage);
            }

            return View();
        }

        TempData["SuccessMessage"] = "Employee was created successfully.";

        return RedirectToAction("Index", "Employee");
    }

    //[HttpGet]
    //public async Task<IActionResult> Edit(int id)
    //{

    //}

    //[HttpPut]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Edit(EmployeeModel employee)
    //{

    //}

    //[HttpGet]
    //public async Task<IActionResult> Delete(int id)
    //{

    //}

    //[HttpDelete]
    //public async Task<IActionResult> DeleteEmp(int id)
    //{

    //}

    private async Task<List<DepartmentModel>> LoadDepartments()
    {
        var departmentsResponse = await _employeeService.GetDepartments();
        var response = await ResponseParser.DepartmentsResponse(departmentsResponse);

        return response.Payload.Select(
            department => _mapper.Map<DepartmentModel>(department)).ToList();
    }

    private async Task<List<TownModel>> LoadTowns()
    {
        var apiResponse = await _employeeService.GetTowns();
        var response = await ResponseParser.TownsResponse(apiResponse);

        return response.Payload.Select(
            town => _mapper.Map<TownModel>(town)).ToList();
    }

    private async Task<List<SalaryModel>> LoadSalaries()
    {
        var apiResponse = await _employeeService.GetSalaries();
        var response = await ResponseParser.SalariesResponse(apiResponse);

        return response.Payload.Select(
            town => _mapper.Map<SalaryModel>(town)).ToList();
    }
}