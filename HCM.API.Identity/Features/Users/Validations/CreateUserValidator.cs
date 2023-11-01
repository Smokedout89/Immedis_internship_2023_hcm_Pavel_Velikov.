namespace HCM.API.Identity.Features.Users.Validations;

using FluentValidation;
using Requests;

public class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email can't be empty.")
            .Matches(
                "^([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-]+)(\\.[a-zA-Z]{2,5}){1,2}$")
            .WithMessage("Please enter a valid email address.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Your password can't be empty")
            .MinimumLength(6)
            .WithMessage("Your password length must be at least 6.")
            .MaximumLength(16)
            .WithMessage("Your password length must not exceed 16.")
            .Matches(@"[A-Z]+")
            .WithMessage("Your password must contain at least one uppercase letter.")
            .Matches(@"[a-z]+")
            .WithMessage("Your password must contain at least one lowercase letter.")
            .Matches(@"[0-9]+")
            .WithMessage("Your password must contain at least one number.");
        //.Matches(@"[\!\?\*\.]+")
        //.WithMessage("Your password must contain at least one (!? *.).");

        RuleFor(x => x.Password)
            .Matches(x => x.RePassword)
            .WithMessage("Password and Re-Password don't match.");
    }
}