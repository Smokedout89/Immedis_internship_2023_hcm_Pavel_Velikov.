namespace HCM.Domain.PostgresModels;

using Abstractions.Models;

public class SalaryDb : BaseEntity
{
    public decimal GrossSalary { get; set; }
    public decimal NetSalary => GrossSalary * 0.8m;
    public bool BonusAvailable { get; set; }
    public virtual ICollection<EmployeeDb> Employees { get; set; } = new HashSet<EmployeeDb>();
}