namespace HCM.API.Employees.Features.Course.Handlers;

using MediatR;
using Requests;
using Services.Course;

public class CreateCourseHandler : IRequestHandler<CreateCourseRequest, IResult>
{
    private readonly ICourseService _courseService;

    public CreateCourseHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<IResult> Handle(CreateCourseRequest request, CancellationToken cancellationToken)
    {
        return await _courseService.CreateCourse(request);
    }
}