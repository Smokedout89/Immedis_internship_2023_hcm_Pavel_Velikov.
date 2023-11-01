namespace HCM.API.Identity.Features.Users.Handlers;

using MediatR;
using Requests;
using Services.User;

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