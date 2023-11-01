namespace HCM.Web.APIServices;

public class ApiEmployeeService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    public ApiEmployeeService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiBaseUrl = configuration["ApiEmployeeBaseUrl"]!;
    }
}