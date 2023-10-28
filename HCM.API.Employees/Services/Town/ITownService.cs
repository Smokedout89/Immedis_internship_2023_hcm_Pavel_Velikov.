namespace HCM.API.Employees.Services.Town;

using Features.Town.Requests;

public interface ITownService
{
    Task<IResult> CreateTown(CreateTownRequest request);
    Task<IResult> GetTowns();
    Task<IResult> GetTownById(string id);
    Task<IResult> UpdateTown(UpdateTownRequest request);
    Task<IResult> DeleteTown(string id);
}