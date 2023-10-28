namespace HCM.API.Employees.Features.Address.Validations;

using FluentValidation;
using Requests;

public class UpdateAddressValidator : AbstractValidator<UpdateAddressRequest>
{
    public UpdateAddressValidator()
    {
        RuleFor(x => x.Id)
            .Must(ValidateGuid)
            .WithMessage("Entered Id is not a valid Guid.");

        RuleFor(x => x.StreetName)
            .MinimumLength(4)
            .WithMessage("Street name can't be less than 4 letters.")
            .MaximumLength(30)
            .WithMessage("Street name can't be more than 30 letters.");

        RuleFor(x => x.StreetNumber)
            .NotEmpty()
            .GreaterThan(0)
            .LessThan(10000);
    }

    private bool ValidateGuid(string id)
    {
        return Guid.TryParse(id, out _);
    }
}