namespace HCM.API.Employees.Features.Salary.Handlers;

using MediatR;
using Requests;
using Services.Salary;

public class GetSalaryHandler : IRequestHandler<GetSalaryRequest, IResult>
{
    private readonly ISalaryService _salaryService;

    public GetSalaryHandler(ISalaryService salaryService)
    {
        _salaryService = salaryService;
    }

    public async Task<IResult> Handle(GetSalaryRequest request, CancellationToken cancellationToken)
    {
        return await _salaryService.GetSalaryById(request.Id);
    }
}