namespace HCM.API.Employees.Features.Salary.Handlers;

using MediatR;
using Requests;
using Services.Salary;

public class DeleteSalaryHandler : IRequestHandler<DeleteSalaryRequest, IResult>
{
    private readonly ISalaryService _salaryService;

    public DeleteSalaryHandler(ISalaryService salaryService)
    {
        _salaryService = salaryService;
    }

    public async Task<IResult> Handle(DeleteSalaryRequest request, CancellationToken cancellationToken)
    {
        return await _salaryService.DeleteSalary(request.Id);
    }
}