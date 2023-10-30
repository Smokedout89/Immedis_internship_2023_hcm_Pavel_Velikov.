namespace HCM.API.Employees.Features.Salary.Handlers;

using MediatR;
using Requests;
using Services.Salary;

public class CreateSalaryHandler : IRequestHandler<CreateSalaryRequest, IResult>
{
    private readonly ISalaryService _salaryService;

    public CreateSalaryHandler(ISalaryService salaryService)
    {
        _salaryService = salaryService;
    }

    public async Task<IResult> Handle(CreateSalaryRequest request, CancellationToken cancellationToken)
    {
        return await _salaryService.CreateSalary(request);
    }
}