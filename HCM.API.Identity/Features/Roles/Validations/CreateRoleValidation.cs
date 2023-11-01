namespace HCM.API.Identity.Features.Roles.Validations;

using FluentValidation;
using Requests;

public class CreateRoleValidation : AbstractValidator<CreateRoleRequest>
{
    public CreateRoleValidation()
    {
        RuleFor(x => x.Name)
            .MinimumLength(4)
            .WithMessage("Role length can't be less than 4.")
            .MaximumLength(12)
            .WithMessage("Role length can't be more than 12.");
    }
}