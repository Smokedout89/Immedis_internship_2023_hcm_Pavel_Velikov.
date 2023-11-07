namespace HCM.Web.Areas.Admin.Controllers;

using MapsterMapper;
using Services.Contracts;
using Microsoft.AspNetCore.Mvc;

public class CourseController : Controller
{
    private readonly IMapper _mapper;
    private readonly IEmployeeService _employeeService;

    public CourseController(IMapper mapper, IEmployeeService employeeService)
    {
        _mapper = mapper;
        _employeeService = employeeService;
    }

    public IActionResult Index()
    {
        return View();
    }
}