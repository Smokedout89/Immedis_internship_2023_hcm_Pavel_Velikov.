namespace HCM.Web.Services;

using Models;
using Contracts;

public class EmployeeService : IEmployeeService
{
    private readonly string _apiBaseUrl;
    private readonly IHttpClientFactory _clientFactory;

    public EmployeeService(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _clientFactory = clientFactory;
        _apiBaseUrl = configuration["ApiEmployeeBaseUrl"]!;
    }

    // Employees

    public async Task<HttpResponseMessage> GetEmployees()
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/employees";

        var response = await client.GetAsync(requestUri);

        return response;
    }

    public async Task<HttpResponseMessage> GetEmployee(string id)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/employees/{id}";

        var response = await client.GetAsync(requestUri);

        return response;
    }

    public async Task<HttpResponseMessage> CreateEmployee(EmployeeCreateModel model)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/employees";

        var response = await client.PostAsJsonAsync(requestUri, model);

        return response;
    }

    public async Task<HttpResponseMessage> EditEmployee(EmployeeUpdateModel model)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/employees/{model.Id}";

        var response = await client.PutAsJsonAsync(requestUri, model);

        return response;
    }

    public async Task<HttpResponseMessage> DeleteEmployee(string id)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/employees/{id}";

        var response = await client.DeleteAsync(requestUri);

        return response;
    }
    
    // Address

    public async Task<HttpResponseMessage> CreateAddress(AddressCreateModel model)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/addresses";

        var response = await client.PostAsJsonAsync(requestUri, model);

        return response;
    }

    public async Task<HttpResponseMessage> GetAddress(string id)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/addresses/{id}";

        var response = await client.GetAsync(requestUri);

        return response;
    }

    // Courses

    public async Task<HttpResponseMessage> GetCourses()
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/courses";

        var response = await client.GetAsync(requestUri);

        return response;
    }

    public async Task<HttpResponseMessage> GetCourse(string id)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/courses/{id}";

        var response = await client.GetAsync(requestUri);

        return response;
    }

    public async Task<HttpResponseMessage> CreateCourse(CourseCreateModel model)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/courses";

        var response = await client.PostAsJsonAsync(requestUri, model);

        return response;
    }

    public async Task<HttpResponseMessage> EditCourse(CourseModel model)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/courses/{model.Id}";

        var response = await client.PutAsJsonAsync(
            requestUri, new CourseCreateModel { Name = model.Name });

        return response;
    }

    public async Task<HttpResponseMessage> DeleteCourse(string id)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/courses/{id}";

        var response = await client.DeleteAsync(requestUri);

        return response;
    }

    public async Task<HttpResponseMessage> CourseAddEmployee(EmployeeCourseModel model)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/courses/{model.CourseId}/add/{model.EmployeeId}";

        var response = await client.PostAsJsonAsync(requestUri, model);

        return response;
    }

    public async Task<HttpResponseMessage> CourseEmployees(string courseId)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/courses/{courseId}/employees";

        var response = await client.GetAsync(requestUri);

        return response;
    }

    // Departments

    public async Task<HttpResponseMessage> GetDepartments()
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/departments";

        var response = await client.GetAsync(requestUri);

        return response;
    }

    public async Task<HttpResponseMessage> GetDepartment(string id)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/departments/{id}";

        var response = await client.GetAsync(requestUri);

        return response;
    }

    public async Task<HttpResponseMessage> CreateDepartment(DepartmentCreateModel model)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/departments";

        var response = await client.PostAsJsonAsync(requestUri, model);

        return response;
    }

    public async Task<HttpResponseMessage> EditDepartment(DepartmentModel model)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/departments/{model.Id}";

        var response = await client.PutAsJsonAsync(
            requestUri, new DepartmentCreateModel { Name = model.Name});

        return response;
    }

    public async Task<HttpResponseMessage> DeleteDepartment(string id)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/departments/{id}";

        var response = await client.DeleteAsync(requestUri);

        return response;
    }

    // Towns

    public async Task<HttpResponseMessage> GetTowns()
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/towns";

        var response = await client.GetAsync(requestUri);

        return response;
    }

    public async Task<HttpResponseMessage> GetTown(string id)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/towns/{id}";

        var response = await client.GetAsync(requestUri);

        return response;
    }

    public async Task<HttpResponseMessage> CreateTown(TownCreateModel model)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/towns";

        var response = await client.PostAsJsonAsync(requestUri, model);

        return response;
    }

    public async Task<HttpResponseMessage> EditTown(TownModel model)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/towns/{model.Id}";

        var response = await client.PutAsJsonAsync(
            requestUri, new TownModel { Name = model.Name });

        return response;
    }

    public async Task<HttpResponseMessage> DeleteTown(string id)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/towns/{id}";

        var response = await client.DeleteAsync(requestUri);

        return response;
    }

    // Salaries

    public async Task<HttpResponseMessage> GetSalaries()
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/salaries";

        var response = await client.GetAsync(requestUri);

        return response;
    }

    public async Task<HttpResponseMessage> GetSalary(string id)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/salaries/{id}";

        var response = await client.GetAsync(requestUri);

        return response;
    }

    public async Task<HttpResponseMessage> CreateSalary(SalaryCreateModel model)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/salaries";

        var response = await client.PostAsJsonAsync(requestUri, model);

        return response;
    }

    public async Task<HttpResponseMessage> EditSalary(SalaryModel model)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/salaries/{model.Id}";

        var response = await client.PutAsJsonAsync(requestUri,
            new SalaryModel
            {
                GrossSalary = model.GrossSalary,
                BonusAvailable = model.BonusAvailable
            });

        return response;
    }

    public async Task<HttpResponseMessage> DeleteSalary(string id)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/salaries/{id}";

        var response = await client.DeleteAsync(requestUri);

        return response;
    }
}