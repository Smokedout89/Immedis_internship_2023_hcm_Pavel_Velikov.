namespace HCM.API.Employees.Features.Employee.Handlers;

using MediatR;
using Requests;
using Services.Employee;

public class GetEmployeesHandler : IRequestHandler<GetEmployeesRequest, IResult>
{
    private readonly IEmployeeService _employeeService;

    public GetEmployeesHandler(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    public async Task<IResult> Handle(GetEmployeesRequest request, CancellationToken cancellationToken)
    {
        return await _employeeService.GetEmployees();
    }
}