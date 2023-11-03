namespace HCM.Web.Areas.User.Controllers;

using MapsterMapper;
using Models;
using Responses;
using Services.Contracts;
using Microsoft.AspNetCore.Mvc;

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

        var employees = new List<EmployeeModel>();

        foreach (var employee in response.Payload)
        {
            employees.Add(_mapper.Map<EmployeeModel>(employee));
        }

        return View(employees);
    }
}