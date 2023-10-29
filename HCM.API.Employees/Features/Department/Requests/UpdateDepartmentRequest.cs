namespace HCM.API.Employees.Features.Department.Requests;

using Infrastructure.Requests;

public class UpdateDepartmentRequest : BaseIdRequest
{
    public string Name { get; set; } = string.Empty;
}