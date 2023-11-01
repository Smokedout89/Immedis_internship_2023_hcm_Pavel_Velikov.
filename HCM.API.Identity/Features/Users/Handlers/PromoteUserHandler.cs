namespace HCM.API.Identity.Features.Users.Handlers;

using MediatR;
using Requests;
using Services.User;

public class PromoteUserHandler : IRequestHandler<PromoteUserRequest, IResult>
{
    private readonly IUserService _userService;

    public PromoteUserHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IResult> Handle(PromoteUserRequest request, CancellationToken cancellationToken)
    {
        return await _userService.PromoteUser(request.Id);
    }
}