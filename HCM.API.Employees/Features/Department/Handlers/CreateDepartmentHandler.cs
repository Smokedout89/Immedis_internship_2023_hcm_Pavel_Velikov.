namespace HCM.API.Employees.Features.Department.Handlers;

using MediatR;
using Requests;
using Services.Department;

public class CreateDepartmentHandler : IRequestHandler<CreateDepartmentRequest, IResult>
{
    private readonly IDepartmentService _departmentService;

    public CreateDepartmentHandler(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public async Task<IResult> Handle(
        CreateDepartmentRequest request, CancellationToken cancellationToken)
    {
        return await _departmentService.CreateDepartment(request);
    }
}