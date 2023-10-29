namespace HCM.API.Employees.Features.Department.Validations;

using FluentValidation;
using Requests;

public class GetDepartmentValidation : AbstractValidator<GetDepartmentRequest>
{
    public GetDepartmentValidation()
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