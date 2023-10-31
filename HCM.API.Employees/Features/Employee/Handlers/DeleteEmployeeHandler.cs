namespace HCM.API.Employees.Features.Employee.Handlers;

using MediatR;
using Requests;
using Services.Employee;

public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeRequest, IResult>
{
    private readonly IEmployeeService _employeeService;

    public DeleteEmployeeHandler(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    public async Task<IResult> Handle(DeleteEmployeeRequest request, CancellationToken cancellationToken)
    {
        return await _employeeService.DeleteEmployee(request.Id);
    }
}