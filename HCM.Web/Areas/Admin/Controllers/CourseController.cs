namespace HCM.Web.Areas.Admin.Controllers;

using Models;
using Responses;
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

    public async Task<IActionResult> Index()
    {
        var apiResponse = await _employeeService.GetCourses();
        var response = await ResponseParser.CoursesResponse(apiResponse);

        var courses = response.Payload.Select(
            course => _mapper.Map<CourseModel>(course)).ToList();

        return View(courses);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CourseCreateModel model)
    {
        var apiResponse = await _employeeService.CreateCourse(model);

        if (!apiResponse.IsSuccessStatusCode)
        {
            var errorMessages = await ResponseParser.ErrorResponse(apiResponse);

            foreach (var errorMessage in errorMessages)
            {
                ModelState.AddModelError(string.Empty, errorMessage);
            }

            return View();
        }

        TempData["SuccessMessage"] = "Course was created successfully.";

        return RedirectToAction("Index", "Course");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        var apiResponse = await _employeeService.GetCourse(id);
        var response = await ResponseParser.CourseResponse(apiResponse);

        return View(_mapper.Map<CourseModel>(response.Payload));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CourseModel model)
    {
        var apiResponse = await _employeeService.EditCourse(model);

        if (!apiResponse.IsSuccessStatusCode)
        {
            var errorMessages = await ResponseParser.ErrorResponse(apiResponse);

            foreach (var errorMessage in errorMessages)
            {
                ModelState.AddModelError(string.Empty, errorMessage);
            }

            return View();
        }

        TempData["SuccessMessage"] = "Course was edited successfully.";

        return RedirectToAction("Index", "Course");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(string id)
    {
        var apiResponse = await _employeeService.GetCourse(id);
        var response = await ResponseParser.CourseResponse(apiResponse);

        return View(_mapper.Map<CourseModel>(response.Payload));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteCourse(string id)
    {
        await _employeeService.DeleteCourse(id);

        TempData["SuccessMessage"] = "Course was deleted successfully.";

        return RedirectToAction("Index", "Course");
    }
}