namespace HCM.API.Employees.Features.Department.Handlers;

using HCM.API.Employees.Services.Department;

using MediatR;
using Requests;

public class GetDepartmentHandler : IRequestHandler<GetDepartmentRequest, IResult>
{
    private readonly IDepartmentService _departmentService;

    public GetDepartmentHandler(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public async Task<IResult> Handle(
        GetDepartmentRequest request, CancellationToken cancellationToken)
    {
        return await _departmentService.GetDepartmentById(request.Id);
    }
}