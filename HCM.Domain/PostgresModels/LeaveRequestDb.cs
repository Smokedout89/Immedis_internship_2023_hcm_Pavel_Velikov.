namespace HCM.Domain.PostgresModels;

using System.ComponentModel.DataAnnotations.Schema;

public class LeaveRequestDb : BaseEntity
{
    [ForeignKey(nameof(EmployeeDb))]
    public string EmployeeId { get; set; } = string.Empty;
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool IsApproved { get; set; }
    public virtual EmployeeDb Employee { get; set; } = null!;
}