namespace HCM.API.Employees.Features.Salary.Responses;

public class SalaryResponse
{
    public string Id { get; set; } = string.Empty;
    public decimal GrossSalary { get; set; }
    public decimal NetSalary { get; set; }
    public bool BonusAvailable { get; set; }
}