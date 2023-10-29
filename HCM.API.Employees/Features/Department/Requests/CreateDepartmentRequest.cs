namespace HCM.API.Employees.Features.Department.Requests;

using Infrastructure.Requests;

public class CreateDepartmentRequest : BaseRequest
{
    public string Name { get; set; } = string.Empty;
}