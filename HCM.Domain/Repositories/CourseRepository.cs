﻿namespace HCM.Domain.Repositories;

using PostgresModels;
using Abstractions.Models;
using Abstractions.Repositories;

using MapsterMapper;
using Microsoft.EntityFrameworkCore;

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
        var course = await _context.Courses.FirstOrDefaultAsync(
            n => n.Name == courseName);

        return _mapper.Map<Course>(course!);
    }
}