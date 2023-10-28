namespace HCM.API.Employees.Features.Town.Handlers;

using MediatR;
using Requests;
using Services.Town;

public class DeleteTownHandler : IRequestHandler<DeleteTownRequest, IResult>
{
    private readonly ITownService _townService;

    public DeleteTownHandler(ITownService townService)
    {
        _townService = townService;
    }

    public async Task<IResult> Handle(DeleteTownRequest request, CancellationToken cancellationToken)
    {
        return await _townService.DeleteTown(request.Id);
    }
}