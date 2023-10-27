namespace HCM.Api.Identity.Features.Users.Handlers;

using Requests;
using Services.User;

using MediatR;

public class GetUserHandler : IRequestHandler<GetUserRequest, IResult>
{
    private readonly IUserService _userService;

    public GetUserHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<IResult> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        return await _userService.GetUser(request.Id);
    }
}