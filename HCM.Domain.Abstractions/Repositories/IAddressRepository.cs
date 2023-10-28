namespace HCM.Domain.Abstractions.Repositories;

using Models;

public interface IAddressRepository : IRepository<Address>
{
    Task<Address?> GetAddressByStreetName(string streetName);
}