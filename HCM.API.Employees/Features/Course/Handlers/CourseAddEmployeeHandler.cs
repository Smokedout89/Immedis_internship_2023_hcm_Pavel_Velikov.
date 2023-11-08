namespace HCM.API.Employees.Features.Course.Handlers;

using HCM.API.Employees.Services.Course;

using MediatR;
using Requests;

public class CourseAddEmployeeHandler : IRequestHandler<CourseAddEmployeeRequest, IResult>
{
    private readonly ICourseService _courseService;

    public CourseAddEmployeeHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<IResult> Handle(CourseAddEmployeeRequest request, CancellationToken cancellationToken)
    {
        return await _courseService.AddEmployeeToCourse(request);
    }
}