namespace HCM.API.Employees.Features.Department.Handlers;

using HCM.API.Employees.Services.Department;

using MediatR;
using Requests;

public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentRequest, IResult>
{
    private readonly IDepartmentService _departmentService;

    public UpdateDepartmentHandler(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public async Task<IResult> Handle(
        UpdateDepartmentRequest request, CancellationToken cancellationToken)
    {
        return await _departmentService.UpdateDepartment(request);
    }
}