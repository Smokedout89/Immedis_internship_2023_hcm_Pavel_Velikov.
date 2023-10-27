namespace HCM.Domain.PostgresModels;

using System.ComponentModel.DataAnnotations.Schema;

public class EmployeeCourseDb
{
    [ForeignKey(nameof(EmployeeDb))]
    public string EmployeeId { get; set; } = string.Empty;
    public virtual EmployeeDb Employee { get; set; } = null!;

    [ForeignKey(nameof(CourseDb))]
    public string CourseId { get; set; } = string.Empty;
    public virtual CourseDb Course { get; set; } = null!;
}