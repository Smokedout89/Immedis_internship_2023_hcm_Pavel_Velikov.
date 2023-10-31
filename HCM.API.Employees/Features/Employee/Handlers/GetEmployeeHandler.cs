namespace HCM.API.Employees.Features.Employee.Handlers;

using MediatR;
using Requests;
using Services.Employee;

public class GetEmployeeHandler : IRequestHandler<GetEmployeeRequest, IResult>
{
    private readonly IEmployeeService _employeeService;

    public GetEmployeeHandler(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    public async Task<IResult> Handle(GetEmployeeRequest request, CancellationToken cancellationToken)
    {
        return await _employeeService.GetEmployeeById(request.Id);
    }
}