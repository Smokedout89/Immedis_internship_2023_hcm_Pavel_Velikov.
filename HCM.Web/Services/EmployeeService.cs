namespace HCM.Web.Services;

using Contracts;

public class EmployeeService : IEmployeeService
{
    private readonly string _apiBaseUrl;
    private readonly HttpClient _httpClient;

    public EmployeeService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiBaseUrl = configuration["ApiEmployeeBaseUrl"]!;
    }
}