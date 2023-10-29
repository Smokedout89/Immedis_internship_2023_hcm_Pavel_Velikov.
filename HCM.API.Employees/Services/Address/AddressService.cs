namespace HCM.API.Employees.Services.Address;

using Infrastructure.Responses;
using Features.Address.Requests;
using Domain.Abstractions.Models;
using Features.Address.Responses;
using Domain.Abstractions.Repositories;

using MapsterMapper;

public class AddressService : IAddressService
{
    private readonly IMapper _mapper;
    private readonly ITownRepository _townRepository;
    private readonly IAddressRepository _addressRepository;

    public AddressService(IMapper mapper, IAddressRepository addressRepository, ITownRepository townRepository)
    {
        _mapper = mapper;
        _addressRepository = addressRepository;
        _townRepository = townRepository;
    }

    public async Task<IResult> CreateAddress(CreateAddressRequest request)
    {
        var isCreated = await _addressRepository.GetAddressByStreetNameAndNumber(request.StreetName, request.StreetNumber);

        if (isCreated is not null && isCreated.StreetNumber == request.StreetNumber)
        {
            return Response.BadRequest("Address with the same street and street number is already existing.");
        }

        var isTownCreated = await _townRepository.GetByIdAsync(request.TownId);

        if (isTownCreated is null)
        {
            return Response.BadRequest("There is no existing Town with the provided Id.");
        }

        var address = new Address
        {
            StreetName = request.StreetName,
            StreetNumber = request.StreetNumber, 
            TownId = request.TownId
        };

        await _addressRepository.AddAsync(address);

        return Response.OkData(new AddressResponse
        {
            Id = address.Id,
            StreetName = address.StreetName,
            StreetNumber = address.StreetNumber,
            Town = isTownCreated.Name
        });
    }

    public async Task<IResult> UpdateAddress(UpdateAddressRequest request)
    {
        var address = await _addressRepository.GetByIdAsNoTracking(request.Id);

        if (address is null)
        {
            return Response.BadRequest("There is no Address with the provided Id.");
        }

        var town = await _townRepository.GetByIdAsync(address.TownId);

        address.StreetName = request.StreetName;
        address.StreetNumber = request.StreetNumber;

        await _addressRepository.UpdateAsync(address);

        return Response.OkData(new AddressResponse
        {
            Id = address.Id,
            StreetName = address.StreetName,
            StreetNumber = address.StreetNumber,
            Town = town!.Name
        });
    }

    public async Task<IResult> DeleteAddress(string id)
    {
        var address = await _addressRepository.GetByIdAsync(id);

        if (address is null)
        {
            return Response.BadRequest("There is no Address with the provided Id.");
        }

        await _addressRepository.DeleteAsync(id);

        return Response.Ok();
    }
}