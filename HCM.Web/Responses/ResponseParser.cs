namespace HCM.Web.Responses;

using Newtonsoft.Json;

public static class ResponseParser
{
    public static async Task<string[]> ErrorResponse(HttpResponseMessage apiResponse)
    {
        var jsonResponse = await apiResponse.Content.ReadAsStringAsync();
        var parsedResponse = JsonConvert.DeserializeObject<ErrorResponse>(jsonResponse);

        string[] errorMessages = parsedResponse!
            .ResponseStatus.Message!
            .Split(
                new[] { "\r\n" },
                StringSplitOptions.RemoveEmptyEntries);

        return errorMessages;
    }

    public static async Task<LoginResponse> LoginResponse(HttpResponseMessage apiResponse)
    {
        var jsonResponse = await apiResponse.Content.ReadAsStringAsync();
        var parsedResponse = JsonConvert.DeserializeObject<LoginResponse>(jsonResponse);

        return parsedResponse!;
    }

    public static async Task<EmployeesResponse> EmployeesResponse(HttpResponseMessage apiResponse)
    {
        var jsonResponse = await apiResponse.Content.ReadAsStringAsync();
        var parsedResponse = JsonConvert.DeserializeObject<EmployeesResponse>(jsonResponse);

        return parsedResponse!;
    }

    public static async Task<EmployeeResponse> EmployeeResponse(HttpResponseMessage apiResponse)
    {
        var jsonResponse = await apiResponse.Content.ReadAsStringAsync();
        var parsedResponse = JsonConvert.DeserializeObject<EmployeeResponse>(jsonResponse);
        
        return parsedResponse!;
    }

    public static async Task<DepartmentsResponse> DepartmentsResponse(HttpResponseMessage apiResponse)
    {
        var jsonResponse = await apiResponse.Content.ReadAsStringAsync();
        var parsedResponse = JsonConvert.DeserializeObject<DepartmentsResponse>(jsonResponse);

        return parsedResponse!;
    }

    public static async Task<DepartmentResponse> DepartmentResponse(HttpResponseMessage apiResponse)
    {
        var jsonResponse = await apiResponse.Content.ReadAsStringAsync();
        var parsedResponse = JsonConvert.DeserializeObject<DepartmentResponse>(jsonResponse);

        return parsedResponse!;
    }

    public static async Task<TownsResponse> TownsResponse(HttpResponseMessage apiResponse)
    {
        var jsonResponse = await apiResponse.Content.ReadAsStringAsync();
        var parsedResponse = JsonConvert.DeserializeObject<TownsResponse>(jsonResponse);

        return parsedResponse!;
    }

    public static async Task<TownResponse> TownResponse(HttpResponseMessage apiResponse)
    {
        var jsonResponse = await apiResponse.Content.ReadAsStringAsync();
        var parsedResponse = JsonConvert.DeserializeObject<TownResponse>(jsonResponse);

        return parsedResponse!;
    }

    public static async Task<SalariesResponse> SalariesResponse(HttpResponseMessage apiResponse)
    {
        var jsonResponse = await apiResponse.Content.ReadAsStringAsync();
        var parsedResponse = JsonConvert.DeserializeObject<SalariesResponse>(jsonResponse);

        return parsedResponse!;
    }

    public static async Task<SalaryResponse> SalaryResponse(HttpResponseMessage apiResponse)
    {
        var jsonResponse = await apiResponse.Content.ReadAsStringAsync();
        var parsedResponse = JsonConvert.DeserializeObject<SalaryResponse>(jsonResponse);

        return parsedResponse!;
    }

    public static async Task<AddressResponse> AddressResponse(HttpResponseMessage apiResponse)
    {
        var jsonResponse = await apiResponse.Content.ReadAsStringAsync();
        var parsedResponse = JsonConvert.DeserializeObject<AddressResponse>(jsonResponse);

        return parsedResponse!;
    }

    public static async Task<CourseResponse> CourseResponse(HttpResponseMessage apiResponse)
    {
        var jsonResponse = await apiResponse.Content.ReadAsStringAsync();
        var parsedResponse = JsonConvert.DeserializeObject<CourseResponse>(jsonResponse);

        return parsedResponse!;
    }

    public static async Task<CoursesResponse> CoursesResponse(HttpResponseMessage apiResponse)
    {
        var jsonResponse = await apiResponse.Content.ReadAsStringAsync();
        var parsedResponse = JsonConvert.DeserializeObject<CoursesResponse>(jsonResponse);

        return parsedResponse!;
    }
}