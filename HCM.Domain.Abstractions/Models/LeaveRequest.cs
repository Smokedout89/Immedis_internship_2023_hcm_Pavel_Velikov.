namespace HCM.Domain.Abstractions.Models;

public class LeaveRequest : Model
{
    public string EmployeeId { get; set; } = string.Empty;
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool IsApproved { get; set; }
}