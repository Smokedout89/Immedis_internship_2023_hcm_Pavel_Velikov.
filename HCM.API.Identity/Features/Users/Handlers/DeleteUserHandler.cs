namespace HCM.Api.Identity.Features.Users.Handlers;

using Requests;
using Services.User;

using MediatR;

public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, IResult>
{
    private readonly IUserService _userService;

    public DeleteUserHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IResult> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        return await _userService.DeleteUser(request.Id);
    }
}