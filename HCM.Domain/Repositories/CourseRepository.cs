namespace HCM.Domain.Repositories;

using Abstractions.Models;
using Abstractions.Repositories;

using MapsterMapper;
using PostgresModels;

public class CourseRepository : Repository<Course, CourseDb>, ICourseRepository
{
    public CourseRepository(ApplicationDbContext context, IMapper mapper) 
        : base(context, mapper)
    {
    }
}