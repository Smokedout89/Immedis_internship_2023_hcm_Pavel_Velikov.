namespace HCM.Domain.Repositories;

using Abstractions.Models;
using Abstractions.Repositories;

using MapsterMapper;
using PostgresModels;

public class CourseRepository : Repository<Course, CourseDb>, ICourseRepository
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public CourseRepository(ApplicationDbContext context, IMapper mapper) 
        : base(context, mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<Course?> GetCourseByName(string courseName)
    {
        var course = await _context.Courses.FindAsync(courseName);

        return await Task.FromResult(_mapper.Map<Course>(course!));
    }
}