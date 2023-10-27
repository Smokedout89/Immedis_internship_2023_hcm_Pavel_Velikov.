namespace HCM.Api.Identity.Features.Users.Validation;

using FluentValidation;

using Requests;

public class GetUserValidator : AbstractValidator<GetUserRequest>
{
    public GetUserValidator()
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