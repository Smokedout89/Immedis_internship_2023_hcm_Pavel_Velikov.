namespace HCM.Web.Services;

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

    public async Task<HttpResponseMessage> GetEmployees()
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/employees";

        var response = await client.GetAsync(requestUri);

        return response;
    }
}