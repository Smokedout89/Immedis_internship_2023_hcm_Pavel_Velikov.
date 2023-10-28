namespace HCM.API.Employees.Features.Town.Handlers;

using MediatR;
using Requests;
using Services.Town;

public class UpdateTownHandler : IRequestHandler<UpdateTownRequest, IResult>
{
    private readonly ITownService _townService;

    public UpdateTownHandler(ITownService townService)
    {
        _townService = townService;
    }

    public async Task<IResult> Handle(UpdateTownRequest request, CancellationToken cancellationToken)
    {
        return await _townService.UpdateTown(request);
    }
}