namespace HCM.API.Employees.Features.LeaveRequest.Handlers;

using MediatR;
using Requests;
using Services.LeaveRequest;

public class CreateLeaveRequestHandler : IRequestHandler<CreateLeaveRequest, IResult>
{
    private readonly ILeaveRequestService _leaveRequestService;

    public CreateLeaveRequestHandler(ILeaveRequestService leaveRequestService)
    {
        _leaveRequestService = leaveRequestService;
    }

    public async Task<IResult> Handle(CreateLeaveRequest request, CancellationToken cancellationToken)
    {
        return await _leaveRequestService.CreateLeaveRequest(request);
    }
}