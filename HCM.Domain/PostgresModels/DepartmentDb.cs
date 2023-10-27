namespace HCM.Domain.PostgresModels;

public class DepartmentDb : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<EmployeeDb> Employees { get; set; } = new HashSet<EmployeeDb>();
}