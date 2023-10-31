namespace HCM.API.Employees.Features.Employee.Handlers;

using MediatR;
using Requests;
using Services.Employee;

public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeRequest, IResult>
{
    private readonly IEmployeeService _employeeService;

    public CreateEmployeeHandler(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    public async Task<IResult> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
    {
        return await _employeeService.CreateEmployee(request);
    }
}