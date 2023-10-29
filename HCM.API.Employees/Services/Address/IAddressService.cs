namespace HCM.API.Employees.Services.Address;

using Features.Address.Requests;

public interface IAddressService
{
    Task<IResult> CreateAddress(CreateAddressRequest request);
    Task<IResult> UpdateAddress(UpdateAddressRequest request);
    Task<IResult> DeleteAddress(string id);
}