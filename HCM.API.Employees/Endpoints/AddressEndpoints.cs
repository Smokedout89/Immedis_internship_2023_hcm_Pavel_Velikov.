namespace HCM.API.Employees.Endpoints;

using Abstractions;
using Features.Address.Requests;

using MediatR;

public class AddressEndpoints : IEndpoint
{
    public void RegisterEndpoints(WebApplication app)
    {
        app.MapPost("/api/addresses", CreateAddress);
        app.MapPut("api/addresses/{id}", UpdateAddress);
        app.MapDelete("api/addresses/{id}", DeleteAddress);
    }

    private static async Task<IResult> CreateAddress(
        ISender sender, CreateAddressRequest request)
    {
        return await sender.Send(request);
    }

    private static async Task<IResult> UpdateAddress(
        ISender sender,string id, UpdateAddressRequest request)
    {
        request.Id = id;

        return await sender.Send(request);
    }

    private static async Task<IResult> DeleteAddress(
        ISender sender, string id)
    {
        var request = new DeleteAddressRequest { Id = id};

        return await sender.Send(request);
    }
}