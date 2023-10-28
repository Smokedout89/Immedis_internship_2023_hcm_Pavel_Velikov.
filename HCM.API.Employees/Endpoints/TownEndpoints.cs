namespace HCM.API.Employees.Endpoints;

using Abstractions;
using Features.Town.Requests;

using MediatR;

public class TownEndpoints : IEndpoint
{
    public void RegisterEndpoints(WebApplication app)
    {
        app.MapPost("api/towns", CreateTown);
        app.MapGet("api/towns/{id}", GetTown);
        app.MapGet("api/towns", GetTowns);
        app.MapPut("api/towns/{id}", UpdateTown);
        app.MapDelete("api/towns/{id}", DeleteTown);
    }

    private static async Task<IResult> CreateTown(ISender sender, CreateTownRequest request)
    {
        return await sender.Send(request);
    }

    private static async Task<IResult> GetTown(ISender sender, string id)
    {
        var request = new GetTownRequest { Id = id };

        return await sender.Send(request);
    }

    private static async Task<IResult> GetTowns(ISender sender)
    {
        var request = new GetTownsRequest();

        return await sender.Send(request);
    }

    private static async Task<IResult> UpdateTown(
        ISender sender, string id, UpdateTownRequest request)
    {
        request.Id = id;

        return await sender.Send(request);
    }

    private static async Task<IResult> DeleteTown(ISender sender, string id)
    {
        var request = new DeleteTownRequest { Id = id };

        return await sender.Send(request);
    }
}