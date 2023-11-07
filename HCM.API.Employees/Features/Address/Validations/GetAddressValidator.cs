namespace HCM.API.Employees.Features.Address.Validations;

using FluentValidation;
using Requests;

public class GetAddressValidator : AbstractValidator<GetAddressRequest>
{
    public GetAddressValidator()
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