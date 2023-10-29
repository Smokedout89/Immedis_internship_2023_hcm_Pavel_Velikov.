﻿namespace HCM.API.Employees.Features.Course.Validations;

using FluentValidation;
using Requests;

public class GetCourseValidator : AbstractValidator<GetCourseRequest>
{
    public GetCourseValidator()
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