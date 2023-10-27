namespace HCM.Domain.Abstractions.Models;

public class EmployeeCourse : Model
{
    public string EmployeeId { get; set; } = string.Empty;
    public string CourseId { get; set; } = string.Empty;
}