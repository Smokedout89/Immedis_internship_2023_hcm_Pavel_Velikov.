namespace HCM.API.Employees.Features.Course.Requests;

using Infrastructure.Requests;

public class CourseAddEmployeeRequest : BaseRequest
{
    public string CourseId { get; set; } = string.Empty;
    public string EmployeeId { get; set; } = string.Empty;
}