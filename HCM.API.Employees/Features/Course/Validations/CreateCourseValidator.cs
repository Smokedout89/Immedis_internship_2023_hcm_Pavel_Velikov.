namespace HCM.API.Employees.Features.Course.Validations;

using FluentValidation;
using Requests;

public class CreateCourseValidator : AbstractValidator<CreateCourseRequest>
{
    public CreateCourseValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(3)
            .WithMessage("Entered course must be at least 3 letters.")
            .MaximumLength(20)
            .WithMessage("Entered course must not exceed 20 letters.");
    }
}