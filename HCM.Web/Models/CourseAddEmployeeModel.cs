namespace HCM.Web.Models;

public class CourseAddEmployeeModel
{
    public List<EmployeeModel> Employees { get; set; } = new();
    public CourseModel Course { get; set; } = null!;
}