namespace HCM.Domain.Repositories;

using PostgresModels;
using Abstractions.Models;
using Abstractions.Repositories;

using MapsterMapper;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Address?> GetAddressByStreetNameAndNumber(
        string streetName, int streetNumber)
    {
        var address = await _context.Addresses.FirstOrDefaultAsync(
            n => n.StreetName == streetName && n.StreetNumber == streetNumber);

        return _mapper.Map<Address>(address!);
    }
}