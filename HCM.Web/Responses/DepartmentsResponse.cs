namespace HCM.Web.Responses;

public class DepartmentsResponse : BaseResponse<List<DepartmentPayload>>
{
    
}

public class DepartmentPayload
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}