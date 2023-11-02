namespace HCM.Web.APIServices;

public class EmployeeService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    public EmployeeService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiBaseUrl = configuration["ApiEmployeeBaseUrl"]!;
    }
}