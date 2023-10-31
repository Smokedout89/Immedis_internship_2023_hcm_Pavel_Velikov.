namespace HCM.API.Employees.Features.Employee.Validations;

using FluentValidation;
using Requests;

public class UpdateEmployeeValidation : AbstractValidator<UpdateEmployeeRequest>
{
    public UpdateEmployeeValidation()
    {
        RuleFor(x => x.Id)
            .Must(ValidateGuid)
            .WithMessage("Entered Id is not a valid Guid.");

        RuleFor(x => x.FirstName)
            .MinimumLength(3)
            .WithMessage("First name can't be less than 3 letters.")
            .MaximumLength(20)
            .WithMessage("First name can't be more than 20 letters.");

        RuleFor(x => x.LastName)
            .MinimumLength(3)
            .WithMessage("Last name can't be less than 3 letters.")
            .MaximumLength(20)
            .WithMessage("Last name can't be more than 20 letters.");

        RuleFor(x => x.Age)
            .GreaterThanOrEqualTo(18)
            .WithMessage("Age can't be less than 18 years.")
            .LessThanOrEqualTo(80)
            .WithMessage("Age can't be more that 80 years.");

        RuleFor(x => x.JobTitle)
            .MinimumLength(3)
            .WithMessage("Jot title can't be less than 3 letters.")
            .MaximumLength(20)
            .WithMessage("Job title can't be more than 20 letters.");

        RuleFor(x => x.Gender)
            .IsInEnum()
            .WithMessage("Invalid value for gender");

        RuleFor(x => x.ContractType)
            .IsInEnum()
            .WithMessage("Invalid value for contract type");

        RuleFor(x => x.AddressId)
            .Must(ValidateGuid)
            .WithMessage("Entered Id is not a valid Guid.");

        RuleFor(x => x.DepartmentId)
            .Must(ValidateGuid)
            .WithMessage("Entered Id is not a valid Guid.");

        RuleFor(x => x.SalaryId)
            .Must(ValidateGuid)
            .WithMessage("Entered Id is not a valid Guid.");
    }

    private bool ValidateGuid(string id)
    {
        return Guid.TryParse(id, out _);
    }
}