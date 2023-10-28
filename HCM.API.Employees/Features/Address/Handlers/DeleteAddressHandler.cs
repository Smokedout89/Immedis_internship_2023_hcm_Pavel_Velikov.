namespace HCM.API.Employees.Features.Address.Handlers;

using MediatR;
using Requests;
using Services.Address;

public class DeleteAddressHandler : IRequestHandler<DeleteAddressRequest, IResult>
{
    private readonly IAddressService _addressService;

    public DeleteAddressHandler(IAddressService addressService)
    {
        _addressService = addressService;
    }

    public async Task<IResult> Handle(DeleteAddressRequest request, CancellationToken cancellationToken)
    {
        return await _addressService.DeleteAddress(request.Id);
    }
}