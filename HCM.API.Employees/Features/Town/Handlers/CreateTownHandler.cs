namespace HCM.API.Employees.Features.Town.Handlers;

using MediatR;
using Requests;
using Services.Town;

public class CreateTownHandler : IRequestHandler<CreateTownRequest, IResult>
{
    private readonly ITownService _townService;

    public CreateTownHandler(ITownService townService)
    {
        _townService = townService;
    }

    public async Task<IResult> Handle(CreateTownRequest request, CancellationToken cancellationToken)
    {
        return await _townService.CreateTown(request);
    }
}