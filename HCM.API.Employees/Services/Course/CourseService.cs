namespace HCM.API.Employees.Services.Course;

using Infrastructure.Responses;
using Features.Course.Requests;
using Features.Course.Responses;
using Domain.Abstractions.Models;
using Domain.Abstractions.Repositories;

using MapsterMapper;

public class CourseService : ICourseService
{
    private readonly IMapper _mapper;
    private readonly ICourseRepository _courseRepository;

    public CourseService(IMapper mapper, ICourseRepository courseRepository)
    {
        _mapper = mapper;
        _courseRepository = courseRepository;
    }

    public async Task<IResult> CreateCourse(CreateCourseRequest request)
    {
        var isCreated = await _courseRepository.GetCourseByName(request.Name);

        if (isCreated is not null)
        {
            return Response.BadRequest("Course is already created.");
        }

        var course = new Course { Name = request.Name };
        await _courseRepository.AddAsync(course);

        return Response.OkData(_mapper.Map<CourseResponse>(course));
    }

    public async Task<IResult> GetCourseById(string id)
    {
        var course = await _courseRepository.GetByIdAsync(id);

        if (course is null)
        {
            return Response.BadRequest("There is no Course with the provided Id.");
        }

        return Response.OkData(_mapper.Map<CourseResponse>(course));
    }

    public async Task<IResult> GetCourses()
    {
        var courses = await _courseRepository.GetAllAsync();
        var coursesToReturn = courses.Select(
            course => _mapper.Map<CourseResponse>(course)).ToList();

        return Response.OkData(coursesToReturn);
    }

    public async Task<IResult> UpdateCourse(UpdateCourseRequest request)
    {
        var course = await _courseRepository.GetByIdAsNoTracking(request.Id);

        if (course is null)
        {
            return Response.BadRequest("There is no Course with the provided Id.");
        }

        course.Name = request.Name;
        await _courseRepository.UpdateAsync(course);

        return Response.OkData(_mapper.Map<CourseResponse>(course));
    }

    public async Task<IResult> DeleteCourse(string id)
    {
        var course = await _courseRepository.GetByIdAsync(id);

        if (course is null)
        {
            return Response.BadRequest("There is no Course with the provided Id.");
        }

        await _courseRepository.DeleteAsync(id);

        return Response.Ok();
    }
}