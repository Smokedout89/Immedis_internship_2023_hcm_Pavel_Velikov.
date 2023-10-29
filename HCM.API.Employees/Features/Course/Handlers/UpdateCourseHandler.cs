namespace HCM.API.Employees.Features.Course.Handlers;

using MediatR;
using Requests;
using Services.Course;

public class UpdateCourseHandler : IRequestHandler<UpdateCourseRequest, IResult>
{
    private readonly ICourseService _courseService;

    public UpdateCourseHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<IResult> Handle(UpdateCourseRequest request, CancellationToken cancellationToken)
    {
        return await _courseService.UpdateCourse(request);
    }
}