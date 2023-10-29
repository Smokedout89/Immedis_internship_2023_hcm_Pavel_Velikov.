namespace HCM.API.Employees.Features.Course.Requests;

using Infrastructure.Requests;

public class CreateCourseRequest : BaseRequest
{
    public string Name { get; set; } = string.Empty;
}