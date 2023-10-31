namespace HCM.API.Employees.Endpoints;

using Abstractions;
using Features.Employee.Requests;

using MediatR;

public class EmployeeEndpoints : IEndpoint
{
    public void RegisterEndpoints(WebApplication app)
    {
        app.MapPost("api/employees", CreateEmployee);
        app.MapGet("api/employees/{id}", GetEmployee);
        app.MapGet("api/employees", GetEmployees);
        app.MapPut("api/employees/{id}", UpdateEmployee);
        app.MapDelete("api/employees/{id}", DeleteEmployee);
    }

    private static async Task<IResult> CreateEmployee(
        ISender sender, CreateEmployeeRequest request)
    {
        return await sender.Send(request);
    }

    private static async Task<IResult> GetEmployee(ISender sender, string id)
    {
        var request = new GetEmployeeRequest { Id = id };

        return await sender.Send(request);
    }

    private static async Task<IResult> GetEmployees(ISender sender)
    {
        var request = new GetEmployeesRequest();

        return await sender.Send(request);
    }

    private static async Task<IResult> UpdateEmployee(
        ISender sender, string id, UpdateEmployeeRequest request)
    {
        request.Id = id;

        return await sender.Send(request);
    }

    private static async Task<IResult> DeleteEmployee(
        ISender sender, string id)
    {
        var request = new DeleteEmployeeRequest { Id = id };

        return await sender.Send(request);
    }
}