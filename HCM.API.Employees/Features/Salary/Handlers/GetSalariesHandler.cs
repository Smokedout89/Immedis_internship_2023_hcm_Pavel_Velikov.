namespace HCM.API.Employees.Features.Salary.Handlers;

using MediatR;
using Requests;
using Services.Salary;

public class GetSalariesHandler : IRequestHandler<GetSalariesRequest, IResult>
{
    private readonly ISalaryService _salaryService;

    public GetSalariesHandler(ISalaryService salaryService)
    {
        _salaryService = salaryService;
    }

    public async Task<IResult> Handle(GetSalariesRequest request, CancellationToken cancellationToken)
    {
        return await _salaryService.GetSalaries();
    }
}