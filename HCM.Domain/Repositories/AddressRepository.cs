namespace HCM.Domain.Repositories;

using Abstractions.Models;
using Abstractions.Repositories;

using MapsterMapper;
using PostgresModels;

public class AddressRepository : Repository<Address, AddressDb>, IAddressRepository
{
    public AddressRepository(ApplicationDbContext context, IMapper mapper) 
        : base(context, mapper)
    {
    }
}