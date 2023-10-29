namespace HCM.API.Employees.Features.Department.Handlers;

using HCM.API.Employees.Services.Department;

using MediatR;
using Requests;

public class GetDepartmentsHandler : IRequestHandler<GetDepartmentsRequest, IResult>
{
    private readonly IDepartmentService _departmentService;

    public GetDepartmentsHandler(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public async Task<IResult> Handle(
        GetDepartmentsRequest request, CancellationToken cancellationToken)
    {
        return await _departmentService.GetDepartments();
    }
}