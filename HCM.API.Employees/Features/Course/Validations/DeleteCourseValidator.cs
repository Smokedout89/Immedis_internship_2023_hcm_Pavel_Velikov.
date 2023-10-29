namespace HCM.API.Employees.Features.Course.Validations;

using FluentValidation;
using Requests;

public class DeleteCourseValidator : AbstractValidator<DeleteCourseRequest>
{
    public DeleteCourseValidator()
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