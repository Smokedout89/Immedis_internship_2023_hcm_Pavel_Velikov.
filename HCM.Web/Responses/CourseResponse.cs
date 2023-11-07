namespace HCM.Web.Responses;

using Domain.Abstractions.Models;

public class CourseResponse : BaseResponse<CoursePayload>
{
}

public class CoursePayload
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public List<EmployeeCourse> EmployeeCourses { get; set; } = new();
}