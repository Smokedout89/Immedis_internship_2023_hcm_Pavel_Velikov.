namespace HCM.API.Employees.Features.Town.Validations;

using FluentValidation;
using Requests;

public class GetTownValidator : AbstractValidator<GetTownRequest>
{
    public GetTownValidator()
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