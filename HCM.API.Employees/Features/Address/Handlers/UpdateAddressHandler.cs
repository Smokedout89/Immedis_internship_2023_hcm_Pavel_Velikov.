namespace HCM.API.Employees.Features.Address.Handlers;

using MediatR;
using Requests;
using Services.Address;

public class UpdateAddressHandler : IRequestHandler<UpdateAddressRequest, IResult>
{
    private readonly IAddressService _addressService;

    public UpdateAddressHandler(IAddressService addressService)
    {
        _addressService = addressService;
    }

    public async Task<IResult> Handle(UpdateAddressRequest request, CancellationToken cancellationToken)
    {
        return await _addressService.UpdateAddress(request);
    }
}