namespace HCM.API.Identity.Features.Users.Handlers;

using MediatR;
using Requests;
using Services.User;

public class LoginUserHandler : IRequestHandler<LoginUserRequest, IResult>
{
    private readonly IUserService _userService;

    public LoginUserHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IResult> Handle(LoginUserRequest request, CancellationToken cancellationToken)
    {
        return await _userService.Login(request);
    }
}