namespace HCM.API.Employees.Endpoints;

using Abstractions;

using Features.Salary.Requests;

using MediatR;

public class SalaryEndpoints : IEndpoint
{
    public void RegisterEndpoints(WebApplication app)
    {
        app.MapPost("api/salaries", CreateSalary);
        app.MapGet("api/salaries/{id}", GetSalary);
        app.MapPut("api/salaries/{id}", UpdateSalary);
        app.MapDelete("api/salaries/{id}", DeleteSalary);
    }

    public static async Task<IResult> CreateSalary(
        ISender sender, CreateSalaryRequest request)
    {
        return await sender.Send(request);
    }

    public static async Task<IResult> GetSalary(ISender sender, string id)
    {
        var request = new GetSalaryRequest { Id = id };

        return await sender.Send(request);
    }

    public static async Task<IResult> UpdateSalary(
        ISender sender, string id, UpdateSalaryRequest request)
    {
        request.Id = id;

        return await sender.Send(request);
    }

    public static async Task<IResult> DeleteSalary(ISender sender, string id)
    {
        var request = new DeleteSalaryRequest { Id = id };
        return await sender.Send(request);
    }
}