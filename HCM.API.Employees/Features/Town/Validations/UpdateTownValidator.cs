namespace HCM.API.Employees.Features.Town.Validations;

using FluentValidation;
using Requests;

public class UpdateTownValidator : AbstractValidator<UpdateTownRequest>
{
    public UpdateTownValidator()
    {
        RuleFor(x => x.Id)
            .Must(ValidateGuid)
            .WithMessage("Entered Id is not a valid Guid.");

        RuleFor(x => x.Name)
            .MinimumLength(3)
            .WithMessage("Entered town must be at least 3 letters.")
            .MaximumLength(20)
            .WithMessage("Entered town must not exceed 20 letters.");
    }

    private bool ValidateGuid(string id)
    {
        return Guid.TryParse(id, out _);
    }
}