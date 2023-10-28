namespace HCM.API.Employees.Services.Town;

using Features.Town.Requests;
using Features.Town.Responses;
using Infrastructure.Responses;
using Domain.Abstractions.Models;
using Domain.Abstractions.Repositories;

using MapsterMapper;

public class TownService : ITownService
{
    private readonly IMapper _mapper;
    private readonly ITownRepository _townRepository;

    public TownService(IMapper mapper, ITownRepository townRepository)
    {
        _mapper = mapper;
        _townRepository = townRepository;
    }

    public async Task<IResult> CreateTown(CreateTownRequest request)
    {
        var isCreated = await _townRepository.GetTownByName(request.Name);

        if (isCreated is not null)
        {
            return Response.BadRequest("Town is already created.");
        }

        var town = new Town { Name = request.Name };
        await _townRepository.AddAsync(town);

        return Response.OkData(_mapper.Map<TownResponse>(town));
    }

    public async Task<IResult> GetTowns()
    {
        var towns = await _townRepository.GetAllAsync();
        var townsToReturn = towns.Select(
            town => _mapper.Map<TownResponse>(town)).ToList();

        return Response.OkData(townsToReturn);
    }

    public async Task<IResult> GetTownById(string id)
    {
        var town = await _townRepository.GetByIdAsync(id);
        
        if (town is null)
        {
            return Response.BadRequest("There is no Town with the provided Id.");
        }

        return Response.OkData(_mapper.Map<TownResponse>(town));
    }

    public async Task<IResult> UpdateTown(UpdateTownRequest request)
    {
        var town = await _townRepository.GetByIdAsNoTracking(request.Id);

        if (town is null)
        {
            return Response.BadRequest("There is no Town with the provided Id.");
        }

        town.Name = request.Name;
        await _townRepository.UpdateAsync(town);

        return Response.OkData(_mapper.Map<TownResponse>(town));
    }

    public async Task<IResult> DeleteTown(string id)
    {
        var town = await _townRepository.GetByIdAsync(id);

        if (town is null)
        {
            return Response.BadRequest("There is no Town with the provided Id.");
        }

        await _townRepository.DeleteAsync(id);

        return Response.Ok();
    }
}