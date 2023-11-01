namespace HCM.API.Identity.Features.Users.Validations;

using FluentValidation;
using Requests;

public class LoginUserValidator : AbstractValidator<LoginUserRequest>
{
    public LoginUserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email can't be empty.")
            .Matches(
                "^([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-]+)(\\.[a-zA-Z]{2,5}){1,2}$")
            .WithMessage("Please enter a valid email address.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password can't be empty.")
            .MinimumLength(6)
            .WithMessage("Password length must be at least 6.")
            .MaximumLength(16)
            .WithMessage("Password length must not exceed 16.");
    }
}