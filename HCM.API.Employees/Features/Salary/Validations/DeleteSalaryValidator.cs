namespace HCM.API.Employees.Features.Salary.Validations;

using FluentValidation;
using Requests;

public class DeleteSalaryValidator : AbstractValidator<DeleteSalaryRequest>
{
    public DeleteSalaryValidator()
    {
        RuleFor(x => x.Id)
            .Must(ValidateGuid)
            .WithMessage("Entered Id is not a valid Guid.");
    }

    private bool ValidateGuid(string id)
    {
        return Guid.TryParse(id, out _);
    }
}