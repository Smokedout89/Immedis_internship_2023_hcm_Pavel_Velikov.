namespace HCM.Web.Models;

public class CourseEmployeesModel
{
    public CourseModel Course { get; set; } = null!;
    public List<EmployeeModel> Employees { get; set; } = new();
}