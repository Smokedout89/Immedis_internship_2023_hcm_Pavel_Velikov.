namespace HCM.API.Employees.Features.Town.Validations;

using FluentValidation;
using Requests;

public class CreateTownValidator : AbstractValidator<CreateTownRequest>
{
    public CreateTownValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(3)
            .WithMessage("Entered town must be at least 3 letters.")
            .MaximumLength(20)
            .WithMessage("Entered town must not exceed 20 letters.");
    }
}