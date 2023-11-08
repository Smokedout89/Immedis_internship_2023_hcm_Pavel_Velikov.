namespace HCM.Web.Areas.User.Controllers;

using Models;
using Responses;
using MapsterMapper;
using Services.Contracts;
using Microsoft.AspNetCore.Mvc;

public class EmployeeCoursesController : Controller
{
    private readonly IMapper _mapper;
    private readonly IEmployeeService _employeeService;

    public EmployeeCoursesController(IMapper mapper, IEmployeeService employeeService)
    {
        _mapper = mapper;
        _employeeService = employeeService;
    }

    public async Task<IActionResult> Index()
    {
        var apiResponse = await _employeeService.GetCourses();
        var response = await ResponseParser.CoursesResponse(apiResponse);

        var courses = response.Payload.Select(
            course => _mapper.Map<CourseModel>(course)).ToList();

        return View(courses);
    }

    [HttpGet]
    public async Task<IActionResult> Add(string id)
    {
        var view = await LoadCoursesAndEmployees(id);

        return View(view);
    }

    [HttpPost]
    public async Task<IActionResult> Add(EmployeeCourseModel model)
    {
        var apiResponse = await _employeeService.CourseAddEmployee(model);

        if (!apiResponse.IsSuccessStatusCode)
        {
            var errorMessages = await ResponseParser.ErrorResponse(apiResponse);

            foreach (var errorMessage in errorMessages)
            {
                ModelState.AddModelError(string.Empty, errorMessage);
            }

            var view = await LoadCoursesAndEmployees(model.CourseId);

            return View(view);
        }

        TempData["SuccessMessage"] = "Employee was added to the course successfully.";

        return RedirectToAction("Index", "EmployeeCourses");
    }

    [HttpGet]
    public async Task<IActionResult> ViewEmployees(string id)
    {
        var apiEmployeesResponse = await _employeeService.CourseEmployees(id);
        var employeesResponse = await ResponseParser.EmployeesResponse(apiEmployeesResponse);

        var employees = employeesResponse.Payload.Select(
            employee => _mapper.Map<EmployeeModel>(employee)).ToList();

        var apiCourseResponse = await _employeeService.GetCourse(id);
        var courseResponse = await ResponseParser.CourseResponse(apiCourseResponse);

        var course = _mapper.Map<CourseModel>(courseResponse.Payload);

        return View(new CourseEmployeesModel { Course = course , Employees = employees });
    }

    private async Task<CourseAddEmployeeModel> LoadCoursesAndEmployees(string courseId)
    {
        var view = new CourseAddEmployeeModel();

        var apiEmployeesResponse = await _employeeService.GetEmployees();
        var employeeResponse = await ResponseParser.EmployeesResponse(apiEmployeesResponse);

        var apiCourseResponse = await _employeeService.GetCourse(courseId);
        var courseResponse = await ResponseParser.CourseResponse(apiCourseResponse);

        var employees = employeeResponse.Payload.Select(
            town => _mapper.Map<EmployeeModel>(town)).ToList();
        var course = _mapper.Map<CourseModel>(courseResponse.Payload);

        view.Employees = employees;
        view.Course = course;

        return view;
    }
}