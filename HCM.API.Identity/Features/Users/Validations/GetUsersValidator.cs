namespace HCM.Api.Identity.Features.Users.Validation;

using Requests;
using FluentValidation;

public class GetUsersValidator : AbstractValidator<GetUsersRequest>
{
    public GetUsersValidator()
    {
    }
}