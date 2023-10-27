namespace HCM.Domain.PostgresModels;

public class CourseDb : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<EmployeeCourseDb> EmployeeCourses { get; set; } 
        = new HashSet<EmployeeCourseDb>();
}