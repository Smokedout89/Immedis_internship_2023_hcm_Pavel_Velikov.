namespace HCM.Api.Identity.Features.Roles.Validation;

using Requests;
using FluentValidation;

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