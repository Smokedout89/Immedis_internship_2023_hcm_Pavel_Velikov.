namespace HCM.API.Identity.Features.Users.Handlers;

using MediatR;
using Requests;
using Services.User;

public class GetUsersHandler : IRequestHandler<GetUsersRequest, IResult>
{
    private readonly IUserService _userService;

    public GetUsersHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IResult> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
        return await _userService.GetUsers();
    }
}