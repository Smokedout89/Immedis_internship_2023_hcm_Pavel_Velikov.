namespace HCM.Web.Services;

using Contracts;
using Models;

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

    public async Task<HttpResponseMessage> CreateDepartment(DepartmentModel model)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/departments";

        var response = await client.PostAsJsonAsync(requestUri, model);

        return response;
    }
}