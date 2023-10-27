namespace HCM.Api.Identity.Features.Users.Handlers;

using Requests;
using Services.User;

using MediatR;

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