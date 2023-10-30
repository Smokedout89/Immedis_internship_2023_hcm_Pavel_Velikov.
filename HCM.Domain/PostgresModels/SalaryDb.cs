namespace HCM.Domain.PostgresModels;

public class SalaryDb : BaseEntity
{
    public decimal GrossSalary { get; set; }
    public bool BonusAvailable { get; set; }
    public virtual ICollection<EmployeeDb> Employees { get; set; } = new HashSet<EmployeeDb>();
}