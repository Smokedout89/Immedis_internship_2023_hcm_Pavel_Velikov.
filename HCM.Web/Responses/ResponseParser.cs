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
}