﻿namespace HCM.API.Employees.Services.LeaveRequest;

using Infrastructure.Responses;
using Domain.Abstractions.Models;
using Features.LeaveRequest.Requests;
using Features.LeaveRequest.Responses;
using Domain.Abstractions.Repositories;

using MapsterMapper;

public class LeaveRequestService : ILeaveRequestService
{
    private readonly IMapper _mapper;
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public LeaveRequestService(
        IMapper mapper,
        ILeaveRequestRepository leaveRequestRepository)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
    }

    public async Task<IResult> CreateLeaveRequest(CreateLeaveRequest request)
    {
        //var employee = 

        var leaveRequest = new LeaveRequest
        {
            EmployeeId = request.EmployeeId,
            StartDate = request.StartDate,
            EndDate = request.EndDate
        };

        await _leaveRequestRepository.AddAsync(leaveRequest);

        return Response.OkData(_mapper.Map<LeaveRequestResponse>(leaveRequest));
    }

    public async Task<IResult> DeleteLeaveRequest(string id)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(id);

        if (leaveRequest is null)
        {
            return Response.BadRequest("There is no leave request with the provided Id.");
        }

        await _leaveRequestRepository.DeleteAsync(id);

        return Response.Ok();
    }
}