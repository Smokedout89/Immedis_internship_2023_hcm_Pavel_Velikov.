namespace HCM.API.Employees.Features.LeaveRequest.Validations;

using FluentValidation;
using Requests;

public class DeleteLeaveRequestValidator : AbstractValidator<DeleteLeaveRequest>
{
    public DeleteLeaveRequestValidator()
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