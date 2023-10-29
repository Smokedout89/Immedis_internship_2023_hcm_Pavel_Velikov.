namespace HCM.API.Employees.Features.LeaveRequest.Requests;

using Infrastructure.Requests;

public class CreateLeaveRequest : BaseRequest
{
    public string EmployeeId { get; set; } = string.Empty;
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}