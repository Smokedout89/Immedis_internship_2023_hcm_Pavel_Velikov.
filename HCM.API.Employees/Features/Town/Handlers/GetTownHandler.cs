namespace HCM.API.Employees.Features.Town.Handlers;

using MediatR;
using Requests;
using Services.Town;

public class GetTownHandler : IRequestHandler<GetTownRequest, IResult>
{
    private readonly ITownService _townService;

    public GetTownHandler(ITownService townService)
    {
        _townService = townService;
    }

    public async Task<IResult> Handle(GetTownRequest request, CancellationToken cancellationToken)
    {
        return await _townService.GetTownById(request.Id);
    }
}