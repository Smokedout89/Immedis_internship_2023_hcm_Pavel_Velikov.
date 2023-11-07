namespace HCM.Web.Models;

public class EmployeeDataModel
{
    public string? Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
    public string JobTitle { get; set; } = string.Empty;
    public string DateOfBirth { get; set; } = string.Empty;
    public string HireDate { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string ContractType { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string Salary { get; set; } = string.Empty;
    public string Town { get; set; } = string.Empty;
    public string StreetName { get; set; } = string.Empty;
    public int StreetNumber { get; set; }
}