namespace HCM.API.Employees.Features.Salary.Handlers;

using MediatR;
using Requests;
using Services.Salary;

public class UpdateSalaryHandler : IRequestHandler<UpdateSalaryRequest, IResult>
{
    private readonly ISalaryService _salaryService;

    public UpdateSalaryHandler(ISalaryService salaryService)
    {
        _salaryService = salaryService;
    }

    public async Task<IResult> Handle(UpdateSalaryRequest request, CancellationToken cancellationToken)
    {
        return await _salaryService.UpdateSalary(request);
    }
}