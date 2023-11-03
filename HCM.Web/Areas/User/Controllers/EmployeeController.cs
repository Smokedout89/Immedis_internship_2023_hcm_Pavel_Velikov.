namespace HCM.Web.Areas.User.Controllers;

using Models;
using Responses;
using Services.Contracts;
using Microsoft.AspNetCore.Mvc;

using MapsterMapper;
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
    public IActionResult Create()
    {
        return View();
    }

    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Create(EmployeeCreateModel model)
    //{

    //}

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
}