namespace HCM.API.Employees.Features.Salary.Validations;

using FluentValidation;
using Requests;

public class CreateSalaryValidator : AbstractValidator<CreateSalaryRequest>
{
    public CreateSalaryValidator()
    {
        RuleFor(x => x.GrossSalary)
            .GreaterThan(1000)
            .WithMessage("Salary can't be less than 1000 gross.");
    }
}