namespace HCM.Web.Services;

using System.Text;

using Contracts;
using Models;

using Newtonsoft.Json;

public class EmployeeService : IEmployeeService
{
    private readonly string _apiBaseUrl;
    private readonly IHttpClientFactory _clientFactory;

    public EmployeeService(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _clientFactory = clientFactory;
        _apiBaseUrl = configuration["ApiEmployeeBaseUrl"]!;
    }

    public async Task<HttpResponseMessage> GetEmployees()
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/employees";

        var response = await client.GetAsync(requestUri);

        return response;
    }

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
}