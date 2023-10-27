namespace HCM.Domain.PostgresModels;

using Abstractions.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

public class EmployeeDb : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
    public string JobTitle { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public DateOnly HireDate { get; set; }
    public GenderType Gender { get; set; }
    public ContractType ContractType { get; set; }

    [ForeignKey(nameof(DepartmentDb))]
    public string DepartmentId { get; set; } = string.Empty;
    public virtual DepartmentDb Department { get; set; } = null!;

    [ForeignKey(nameof(AddressDb))]
    public string AddressId { get; set; } = string.Empty;
    public virtual AddressDb Address { get; set; } = null!;

    [ForeignKey(nameof(SalaryDb))]
    public string SalaryId { get; set; } = string.Empty;
    public virtual SalaryDb Salary { get; set; } = null!;

    public virtual ICollection<EmployeeCourseDb> EmployeeCourses { get; set; } = new HashSet<EmployeeCourseDb>();
}