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
        var response = await ResponseParser.EmployeesResponse(apiResponse);

        var employees = response.Payload.Select(
            employee => _mapper.Map<EmployeeModel>(employee)).ToList();

        return View(employees);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var model = new EmployeeDataModel();
        await LoadCollectionsAndAddToViewBag(model);

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(EmployeeDataModel model)
    {
        if (!ModelState.IsValid)
        {
            var returnModel = await LoadCollectionsAndAddToViewBag(model);

            return View(returnModel);
        }

        string addressId;

        var townApiResponse = await _employeeService.GetTown(model.Town);
        var town = await ResponseParser.TownResponse(townApiResponse);

        var isAddressExisting = town.Payload.Addresses.FirstOrDefault(
            x => x.StreetName == model.StreetName && x.StreetNumber == model.StreetNumber);

        if (isAddressExisting is not null)
        {
            addressId = isAddressExisting.Id;
        }
        else
        {
            var address = new AddressCreateModel
            {
                StreetName = model.StreetName,
                StreetNumber = model.StreetNumber,
                TownId = model.Town
            };

            var addressApiResponse = await _employeeService.CreateAddress(address);

            if (!addressApiResponse.IsSuccessStatusCode)
            {
                var addressErrorMessages =
                    await ResponseParser.ErrorResponse(addressApiResponse);

                foreach (var errorMessage in addressErrorMessages)
                {
                    ModelState.AddModelError(string.Empty, errorMessage);
                }

                var returnModel = await LoadCollectionsAndAddToViewBag(model);

                return View(returnModel);
            }

            var response = await ResponseParser.AddressResponse(addressApiResponse);
            addressId = response.Payload.Id;
        }

        var gender = Enum.Parse<GenderType>(model.Gender);
        var contract = Enum.Parse<ContractType>(model.ContractType);
        var dateOfBirth = DateOnly.Parse(model.DateOfBirth);
        var hireDate = DateOnly.Parse(model.HireDate);

        var employee = new EmployeeCreateModel
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Age = model.Age,
            JobTitle = model.JobTitle,
            Gender = gender,
            ContractType = contract,
            DateOfBirth = dateOfBirth,
            HireDate = hireDate,
            DepartmentId = model.Department,
            AddressId = addressId,
            SalaryId = model.Salary
        };

        var employeeApiResponse = await _employeeService.CreateEmployee(employee);

        if (!employeeApiResponse.IsSuccessStatusCode)
        {
            var employeeErrorMessages =
                await ResponseParser.ErrorResponse(employeeApiResponse);

            foreach (var errorMessage in employeeErrorMessages)
            {
                ModelState.AddModelError(string.Empty, errorMessage);
            }

            var returnModel = await LoadCollectionsAndAddToViewBag(model);

            return View(returnModel);
        }

        TempData["SuccessMessage"] = "Employee was created successfully.";

        return RedirectToAction("Index", "Employee");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        var apiEmployeeResponse = await _employeeService.GetEmployee(id);
        var response = await ResponseParser.EmployeeResponse(apiEmployeeResponse);

        var model = _mapper.Map<EmployeeDataModel>(response.Payload);

        List<string> addressAsString = response.Payload.Address.Split(" ").ToList();

        model.StreetNumber = int.Parse(addressAsString.Last());
        addressAsString.RemoveAt(addressAsString.Count - 1);
        model.StreetName = string.Join(" ", addressAsString);

        await LoadCollectionsAndAddToViewBag(model);

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(EmployeeDataModel model)
    {
        if (!ModelState.IsValid)
        {
            var returnModel = await LoadCollectionsAndAddToViewBag(model);

            return View(returnModel);
        }

        var townApiResponse = await _employeeService.GetTown(model.Town);
        var town = await ResponseParser.TownResponse(townApiResponse);

        var isAddressExisting = town.Payload.Addresses.FirstOrDefault(
            a => a.StreetName == model.StreetName && a.StreetNumber == model.StreetNumber);

        string addressId;

        if (isAddressExisting is not null)
        {
            addressId = isAddressExisting.Id;
        }
        else
        {
            var address = new AddressCreateModel
            {
                StreetName = model.StreetName,
                StreetNumber = model.StreetNumber,
                TownId = model.Town
            };

            var addressApiResponse = await _employeeService.CreateAddress(address);

            if (!addressApiResponse.IsSuccessStatusCode)
            {
                var addressErrorMessages =
                    await ResponseParser.ErrorResponse(addressApiResponse);

                foreach (var errorMessage in addressErrorMessages)
                {
                    ModelState.AddModelError(string.Empty, errorMessage);
                }

                var returnModel = await LoadCollectionsAndAddToViewBag(model);

                return View(returnModel);
            }

            var response = await ResponseParser.AddressResponse(addressApiResponse);
            addressId = response.Payload.Id;
        }

        var employeeUpdateModel = new EmployeeUpdateModel
        {
            Id = model.Id!,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Age = model.Age,
            JobTitle = model.JobTitle,
            DateOfBirth = DateOnly.Parse(model.DateOfBirth),
            HireDate = DateOnly.Parse(model.HireDate),
            Gender = Enum.Parse<GenderType>(model.Gender),
            ContractType = Enum.Parse<ContractType>(model.ContractType),
            DepartmentId = model.Department,
            AddressId = addressId,
            SalaryId = model.Salary
        };

        var apiResponse = await _employeeService.EditEmployee(employeeUpdateModel);

        if (!apiResponse.IsSuccessStatusCode)
        {
            var errorMessages = await ResponseParser.ErrorResponse(apiResponse);

            foreach (var errorMessage in errorMessages)
            {
                ModelState.AddModelError(string.Empty, errorMessage);
            }

            return View();
        }

        TempData["SuccessMessage"] = "Employee was edited successfully.";

        return RedirectToAction("Index", "Employee");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(string id)
    {
        var apiResponse = await _employeeService.GetEmployee(id);
        var response = await ResponseParser.EmployeeResponse(apiResponse);

        return View(_mapper.Map<EmployeeModel>(response.Payload));
    }

    [HttpPost]
    public async Task<IActionResult> DeleteEmp(string id)
    {
        await _employeeService.DeleteEmployee(id);

        TempData["SuccessMessage"] = "Employee was deleted successfully.";

        return RedirectToAction("Index", "Employee");
    }

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

    private async Task<EmployeeDataModel> LoadCollectionsAndAddToViewBag(EmployeeDataModel model)
    {
        var departments = await LoadDepartments();
        var salaries = await LoadSalaries();
        var towns = await LoadTowns();

        ViewBag.Departments = departments.Select(x =>
            new SelectListItem(x.Name, x.Id)).ToList();
        ViewBag.Towns = towns.Select(x =>
            new SelectListItem(x.Name, x.Id)).ToList();
        ViewBag.Salaries = salaries.Select(x =>
            new SelectListItem(x.GrossSalary.ToString(
                "c"), x.Id)).ToList();

        return model;
    }
}