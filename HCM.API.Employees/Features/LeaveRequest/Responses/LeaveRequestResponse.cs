namespace HCM.API.Employees.Features.LeaveRequest.Responses;

public class LeaveRequestResponse
{
    public string Id { get; set; } = string.Empty;
    public string EmployeeId { get; set; } = string.Empty;
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool IsApproved { get; set; }
}