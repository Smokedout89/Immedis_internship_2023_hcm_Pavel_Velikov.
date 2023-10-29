namespace HCM.API.Employees.Endpoints;

using Abstractions;
using Features.Course.Requests;

using MediatR;

public class CourseEndpoints : IEndpoint
{
    public void RegisterEndpoints(WebApplication app)
    {
        app.MapPost("api/courses", CreateCourse);
        app.MapGet("api/courses/{id}", GetCourse);
        app.MapGet("api/courses", GetCourses);
        app.MapPut("api/courses/{id}", UpdateCourse);
        app.MapDelete("api/courses/{id}", DeleteCourse);
    }

    private static async Task<IResult> CreateCourse(ISender sender, CreateCourseRequest request)
    {
        return await sender.Send(request);
    }

    private static async Task<IResult> GetCourse(ISender sender, string id)
    {
        var request = new GetCourseRequest() { Id = id };

        return await sender.Send(request);
    }

    private static async Task<IResult> GetCourses(ISender sender)
    {
        var request = new GetCoursesRequest();

        return await sender.Send(request);
    }

    private static async Task<IResult> UpdateCourse(
        ISender sender, string id, UpdateCourseRequest request)
    {
        request.Id = id;

        return await sender.Send(request);
    }

    private static async Task<IResult> DeleteCourse(ISender sender, string id)
    {
        var request = new DeleteCourseRequest() { Id = id };

        return await sender.Send(request);
    }
}