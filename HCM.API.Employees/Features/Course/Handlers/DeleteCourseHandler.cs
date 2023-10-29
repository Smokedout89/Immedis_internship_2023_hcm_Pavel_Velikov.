namespace HCM.API.Employees.Features.Course.Handlers;

using MediatR;
using Requests;
using Services.Course;

public class DeleteCourseHandler : IRequestHandler<DeleteCourseRequest, IResult>
{
    private readonly ICourseService _courseService;

    public DeleteCourseHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<IResult> Handle(DeleteCourseRequest request, CancellationToken cancellationToken)
    {
        return await _courseService.DeleteCourse(request.Id);
    }
}