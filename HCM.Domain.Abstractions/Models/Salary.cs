namespace HCM.Domain.Abstractions.Models;

public class Salary : Model
{
    public decimal GrossSalary { get; set; }
    public decimal NetSalary => GrossSalary * 0.8m;
    public bool BonusAvailable { get; set; }
}