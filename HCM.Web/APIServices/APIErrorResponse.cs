﻿namespace HCM.Web.APIServices;

public class APIErrorResponse
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;
}