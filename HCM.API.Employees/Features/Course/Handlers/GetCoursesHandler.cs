namespace HCM.API.Employees.Features.Course.Handlers;

using MediatR;
using Requests;
using Services.Course;

public class GetCoursesHandler : IRequestHandler<GetCoursesRequest, IResult>
{
    private readonly ICourseService _courseService;

    public GetCoursesHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<IResult> Handle(GetCoursesRequest request, CancellationToken cancellationToken)
    {
        return await _courseService.GetCourses();
    }
}