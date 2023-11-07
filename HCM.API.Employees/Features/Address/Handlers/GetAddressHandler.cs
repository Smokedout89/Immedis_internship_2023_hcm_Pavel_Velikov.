namespace HCM.API.Employees.Features.Address.Handlers;

using MediatR;
using Requests;
using Services.Address;

public class GetAddressHandler : IRequestHandler<GetAddressRequest, IResult>
{
    private readonly IAddressService _addressService;

    public GetAddressHandler(IAddressService addressService)
    {
        _addressService = addressService;
    }

    public async Task<IResult> Handle(GetAddressRequest request, CancellationToken cancellationToken)
    {
        return await _addressService.GetAddressById(request.Id);
    }
}