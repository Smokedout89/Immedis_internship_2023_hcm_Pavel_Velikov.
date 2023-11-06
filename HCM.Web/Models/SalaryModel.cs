namespace HCM.Web.Models;

public class SalaryModel
{
    public string Id { get; set; } = string.Empty;
    public decimal GrossSalary { get; set; }
    public decimal NetSalary { get; set; }
    public bool BonusAvailable { get; set; } = false;
}