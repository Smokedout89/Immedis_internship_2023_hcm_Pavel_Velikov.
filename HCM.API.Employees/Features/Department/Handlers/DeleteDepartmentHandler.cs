namespace HCM.API.Employees.Features.Department.Handlers;

using HCM.API.Employees.Services.Department;

using MediatR;
using Requests;

public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartmentRequest, IResult>
{
    private readonly IDepartmentService _departmentService;

    public DeleteDepartmentHandler(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public async Task<IResult> Handle(
        DeleteDepartmentRequest request, CancellationToken cancellationToken)
    {
        return await _departmentService.DeleteDepartment(request.Id);
    }
}