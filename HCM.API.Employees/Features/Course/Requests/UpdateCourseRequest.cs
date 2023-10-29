namespace HCM.API.Employees.Features.Course.Requests;

using Infrastructure.Requests;

public class UpdateCourseRequest : BaseIdRequest
{
    public string Name { get; set; } = string.Empty;
}