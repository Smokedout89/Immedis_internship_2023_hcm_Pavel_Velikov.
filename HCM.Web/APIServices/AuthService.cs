﻿namespace HCM.Web.APIServices;

using Models;

public class AuthService
{
    private readonly string _apiBaseUrl;
    private readonly IHttpClientFactory _clientFactory;

    public AuthService(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _clientFactory = clientFactory;
        _apiBaseUrl = configuration["ApiIdentityBaseUrl"]!;
    }

    public async Task<HttpResponseMessage> RegisterUserAsync(RegisterModel model)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/users/register";

        var response = await client.PostAsJsonAsync(requestUri, model);

        return response;
    }

    public async Task<HttpResponseMessage> LoginUserAsync(LoginModel model)
    {
        var client = _clientFactory.CreateClient(_apiBaseUrl);
        var requestUri = $"{_apiBaseUrl}/api/users/login";

        var response = await client.PostAsJsonAsync(requestUri, model);

        return response;
    }
}