namespace HCM.API.Employees.Features.Address.Validations;

using FluentValidation;
using Requests;

public class DeleteAddressValidator : AbstractValidator<DeleteAddressRequest>
{
    public DeleteAddressValidator()
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