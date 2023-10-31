namespace HCM.API.Employees.Features.Employee.Handlers;

using MediatR;
using Requests;
using Services.Employee;

public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeRequest, IResult>
{
    private readonly IEmployeeService _employeeService;

    public UpdateEmployeeHandler(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    public async Task<IResult> Handle(UpdateEmployeeRequest request, CancellationToken cancellationToken)
    {
        return await _employeeService.UpdateEmployee(request);
    }
}