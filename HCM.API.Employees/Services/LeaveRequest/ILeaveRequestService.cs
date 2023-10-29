namespace HCM.API.Employees.Services.LeaveRequest;

using Features.LeaveRequest.Requests;

public interface ILeaveRequestService
{
    Task<IResult> CreateLeaveRequest(CreateLeaveRequest request);
    Task<IResult> DeleteLeaveRequest(string id);
}