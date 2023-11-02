namespace HCM.Web.Common;

using Newtonsoft.Json;

public static class ResponseParser
{
    public static async Task<string[]> ErrorResponse(HttpResponseMessage apiResponse)
    {
        var jsonResponse = await apiResponse.Content.ReadAsStringAsync();
        var parsedResponse = JsonConvert.DeserializeObject<APIErrorResponse>(jsonResponse);

        string[] errorMessages = parsedResponse!
            .ResponseStatus.Message!
            .Split(
                new[] { "\r\n" },
                StringSplitOptions.RemoveEmptyEntries);

        return errorMessages;
    }

    public static async Task<APILoginResponse> LoginResponse(HttpResponseMessage apiResponse)
    {
        var jsonResponse = await apiResponse.Content.ReadAsStringAsync();
        var parsedResponse = JsonConvert.DeserializeObject<APILoginResponse>(jsonResponse);

        return parsedResponse!;
    }
}