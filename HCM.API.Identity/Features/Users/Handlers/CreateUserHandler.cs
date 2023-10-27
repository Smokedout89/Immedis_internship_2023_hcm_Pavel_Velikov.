namespace HCM.Api.Identity.Features.Users.Handlers;

using MediatR;
using Requests;
using Services.User;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, IResult>
{
    private readonly IUserService _userService;

    public CreateUserHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IResult> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        return await _userService.Register(request);
    }
}