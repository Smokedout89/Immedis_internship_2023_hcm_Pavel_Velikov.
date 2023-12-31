﻿namespace HCM.Web.Responses;

public class DepartmentResponse : BaseResponse<DepartmentPayload>
{
}

public class DepartmentPayload
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}