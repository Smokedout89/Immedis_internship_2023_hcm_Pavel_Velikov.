namespace HCM.API.Identity.Features.Users.Validations;

using FluentValidation;
using Requests;

public class GetUsersValidator : AbstractValidator<GetUsersRequest>
{
    public GetUsersValidator()
    {
    }
}