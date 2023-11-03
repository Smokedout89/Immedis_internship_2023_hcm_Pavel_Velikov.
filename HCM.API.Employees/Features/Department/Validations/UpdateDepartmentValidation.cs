namespace HCM.API.Employees.Features.Department.Validations;

using FluentValidation;
using Requests;

public class UpdateDepartmentValidation : AbstractValidator<UpdateDepartmentRequest>
{
    public UpdateDepartmentValidation()
    {
        RuleFor(x => x.Id)
            .Must(ValidateGuid)
            .WithMessage("Entered Id is not a valid Guid.");

        RuleFor(x => x.Name)
            .MinimumLength(3)
            .WithMessage("Entered department must be at least 3 letters.")
            .MaximumLength(20)
            .WithMessage("Entered department must not exceed 30 letters.");
    }

    private bool ValidateGuid(string id)
    {
        return Guid.TryParse(id, out _);
    }
}