namespace HCM.Domain.Abstractions.Repositories;

using Models;

public interface ICourseRepository : IRepository<Course>
{
    Task<Course?> GetCourseByName(string courseName);
    Task<EmployeeCourse> AddEmployeeToCourse(string courseId, string employeeId);
}