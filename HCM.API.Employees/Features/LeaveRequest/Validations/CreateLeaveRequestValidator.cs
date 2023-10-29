namespace HCM.API.Employees.Features.LeaveRequest.Validations;

using FluentValidation;
using Requests;

public class CreateLeaveRequestValidator : AbstractValidator<CreateLeaveRequest>
{
    public CreateLeaveRequestValidator()
    {
        RuleFor(x => x.EmployeeId)
            .Must(ValidateGuid)
            .WithMessage("Entered Id is not a valid Guid.");

        RuleFor(x => x.StartDate)
            .NotEmpty()
            .WithMessage("Start date can't be empty.");

        RuleFor(x => x.EndDate)
            .NotEmpty()
            .WithMessage("End date can't be empty.")
            .GreaterThan(x => x.StartDate)
            .WithMessage("End date should be bigger than start date.");
    }

    private bool ValidateGuid(string id)
    {
        return Guid.TryParse(id, out _);
    }
}