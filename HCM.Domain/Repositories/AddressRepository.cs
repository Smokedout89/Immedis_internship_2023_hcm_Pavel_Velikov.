namespace HCM.Domain.Repositories;

using Abstractions.Models;
using Abstractions.Repositories;

using MapsterMapper;
using PostgresModels;

public class AddressRepository : Repository<Address, AddressDb>, IAddressRepository
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public AddressRepository(ApplicationDbContext context, IMapper mapper) 
        : base(context, mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<Address?> GetAddressByStreetName(string streetName)
    {
        var address = await _context.Addresses.FindAsync(streetName);

        return await Task.FromResult(_mapper.Map<Address>(address!));
    }
}