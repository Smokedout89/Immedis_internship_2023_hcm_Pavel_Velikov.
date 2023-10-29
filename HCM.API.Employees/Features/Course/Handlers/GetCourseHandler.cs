namespace HCM.API.Employees.Features.Course.Handlers;

using MediatR;
using Requests;
using Services.Course;

public class GetCourseHandler : IRequestHandler<GetCourseRequest, IResult>
{
    private readonly ICourseService _courseService;

    public GetCourseHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<IResult> Handle(GetCourseRequest request, CancellationToken cancellationToken)
    {
        return await _courseService.GetCourseById(request.Id);
    }
}