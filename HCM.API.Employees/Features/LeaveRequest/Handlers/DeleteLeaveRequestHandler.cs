namespace HCM.API.Employees.Features.LeaveRequest.Handlers;

using MediatR;
using Requests;
using Services.LeaveRequest;

public class DeleteLeaveRequestHandler : IRequestHandler<DeleteLeaveRequest, IResult>
{
    private readonly ILeaveRequestService _leaveRequestService;

    public DeleteLeaveRequestHandler(ILeaveRequestService leaveRequestService)
    {
        _leaveRequestService = leaveRequestService;
    }

    public async Task<IResult> Handle(DeleteLeaveRequest request, CancellationToken cancellationToken)
    {
        return await _leaveRequestService.DeleteLeaveRequest(request.Id);
    }
}