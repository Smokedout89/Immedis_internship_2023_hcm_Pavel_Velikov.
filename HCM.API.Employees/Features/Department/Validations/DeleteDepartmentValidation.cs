namespace HCM.API.Employees.Features.Department.Validations;

using FluentValidation;
using Requests;

public class DeleteDepartmentValidation : AbstractValidator<DeleteDepartmentRequest>
{
    public DeleteDepartmentValidation()
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