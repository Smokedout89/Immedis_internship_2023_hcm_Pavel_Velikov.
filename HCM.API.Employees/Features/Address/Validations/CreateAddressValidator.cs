namespace HCM.API.Employees.Features.Address.Validations;

using FluentValidation;
using Requests;

public class CreateAddressValidator : AbstractValidator<CreateAddressRequest>
{
    public CreateAddressValidator()
    {
        RuleFor(x => x.StreetName)
            .MinimumLength(4)
            .WithMessage("Street name can't be less than 4 letters.")
            .MaximumLength(30)
            .WithMessage("Street name can't be more than 30 letters.");

        RuleFor(x => x.StreetNumber)
            .NotEmpty()
            .GreaterThan(0)
            .LessThan(10000);
        
        RuleFor(x => x.TownId)
            .Must(ValidateGuid)
            .WithMessage("Entered Id is not a valid Guid.");

    }

    private bool ValidateGuid(string id)
    {
        return Guid.TryParse(id, out _);
    }
}