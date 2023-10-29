namespace HCM.API.Employees.Endpoints;

using Abstractions;
using Features.Department.Requests;

using MediatR;

public class DepartmentEndpoints : IEndpoint
{
    public void RegisterEndpoints(WebApplication app)
    {
        app.MapPost("api/departments", CreateDepartment);
        app.MapGet("api/departments/{id}", GetDepartment);
        app.MapGet("api/departments", GetDepartments);
        app.MapPut("api/departments/{id}", UpdateDepartment);
        app.MapDelete("api/departments/{id}", DeleteDepartment);
    }

    private static async Task<IResult> CreateDepartment(ISender sender, CreateDepartmentRequest request)
    {
        return await sender.Send(request);
    }

    private static async Task<IResult> GetDepartment(ISender sender, string id)
    {
        var request = new GetDepartmentRequest() { Id = id };

        return await sender.Send(request);
    }

    private static async Task<IResult> GetDepartments(ISender sender)
    {
        var request = new GetDepartmentsRequest();

        return await sender.Send(request);
    }

    private static async Task<IResult> UpdateDepartment(
        ISender sender, string id, UpdateDepartmentRequest request)
    {
        request.Id = id;

        return await sender.Send(request);
    }

    private static async Task<IResult> DeleteDepartment(ISender sender, string id)
    {
        var request = new DeleteDepartmentRequest { Id = id };

        return await sender.Send(request);
    }
}