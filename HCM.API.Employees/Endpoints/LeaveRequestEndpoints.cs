namespace HCM.API.Employees.Endpoints;

using Abstractions;
using Features.LeaveRequest.Requests;

using MediatR;

public class LeaveRequestEndpoints : IEndpoint
{
    public void RegisterEndpoints(WebApplication app)
    {
        app.MapPost("api/requests", CreateLeaveReq);
        app.MapDelete("api/requests/{id}", DeleteLeaveReq);
    }

    private static async Task<IResult> CreateLeaveReq(
        ISender sender, CreateLeaveRequest request)
    {
        return await sender.Send(request);
    }

    private static async Task<IResult> DeleteLeaveReq(
        ISender sender, string id)
    {
        var request = new DeleteLeaveRequest { Id = id };

        return await sender.Send(request);
    }
}