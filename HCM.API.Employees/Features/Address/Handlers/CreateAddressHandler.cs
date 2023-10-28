namespace HCM.API.Employees.Features.Address.Handlers;

using MediatR;
using Requests;
using Services.Address;

public class CreateAddressHandler : IRequestHandler<CreateAddressRequest, IResult>
{
    private readonly IAddressService _addressService;

    public CreateAddressHandler(IAddressService addressService)
    {
        _addressService = addressService;
    }

    public async Task<IResult> Handle(CreateAddressRequest request, CancellationToken cancellationToken)
    {
        return await _addressService.CreateAddress(request);
    }
}