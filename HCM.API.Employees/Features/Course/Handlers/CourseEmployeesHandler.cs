namespace HCM.API.Employees.Features.Course.Handlers;

using HCM.API.Employees.Services.Course;

using MediatR;
using Requests;

public class CourseEmployeesHandler : IRequestHandler<CourseEmployeesRequest, IResult>
{
    private readonly ICourseService _courseService;

    public CourseEmployeesHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<IResult> Handle(CourseEmployeesRequest request, CancellationToken cancellationToken)
    {
        return await _courseService.ListEmployees(request.Id);
    }
}