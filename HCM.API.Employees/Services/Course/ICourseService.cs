namespace HCM.API.Employees.Services.Course;

using Features.Course.Requests;

public interface ICourseService
{
    Task<IResult> CreateCourse(CreateCourseRequest request);
    Task<IResult> GetCourseById(string id);
    Task<IResult> GetCourses();
    Task<IResult> UpdateCourse(UpdateCourseRequest request);
    Task<IResult> DeleteCourse(string id);
    Task<IResult> AddEmployeeToCourse(CourseAddEmployeeRequest request);
}