namespace HCM.API.Employees.Features.Department.Validations;

using FluentValidation;
using Requests;

public class CreateDepartmentValidation : AbstractValidator<CreateDepartmentRequest>
{
    public CreateDepartmentValidation()
    {
        RuleFor(x => x.Name)
            .MinimumLength(3)
            .WithMessage("Entered department must be at least 3 letters.")
            .MaximumLength(20)
            .WithMessage("Entered department must not exceed 30 letters.");
    }
}