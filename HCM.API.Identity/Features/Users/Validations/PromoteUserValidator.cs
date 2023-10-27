namespace HCM.Api.Identity.Features.Users.Validation;

using Requests;
using FluentValidation;

public class PromoteUserValidator : AbstractValidator<PromoteUserRequest>
{
    public PromoteUserValidator()
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