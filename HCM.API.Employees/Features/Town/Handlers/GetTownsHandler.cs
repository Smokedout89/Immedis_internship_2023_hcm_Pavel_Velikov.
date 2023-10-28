namespace HCM.API.Employees.Features.Town.Handlers;

using MediatR;
using Requests;
using Services.Town;

public class GetTownsHandler : IRequestHandler<GetTownsRequest, IResult>
{
    private readonly ITownService _townService;

    public GetTownsHandler(ITownService townService)
    {
        _townService = townService;
    }

    public async Task<IResult> Handle(GetTownsRequest request, CancellationToken cancellationToken)
    {
        return await _townService.GetTowns();
    }
}