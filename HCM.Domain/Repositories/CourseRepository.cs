﻿namespace HCM.Domain.Repositories;

using MapsterMapper;
using PostgresModels;
using Abstractions.Models;
using Abstractions.Repositories;
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

    public async Task<EmployeeCourse> AddEmployeeToCourse(string courseId, string employeeId)
    {
        var employeeCourseDb = new EmployeeCourseDb { CourseId = courseId, EmployeeId = employeeId };

        await _context.EmployeeCourses.AddAsync(employeeCourseDb);
        await _context.SaveChangesAsync();

        return _mapper.Map<EmployeeCourse>(employeeCourseDb);
    }

    public async Task<List<Employee>> CourseEmployees(string courseId)
    {
        var employeesFromDb = _context.EmployeeCourses.Where(
            c => c.CourseId == courseId).ToList();

        var employeesToReturn = employeesFromDb.Select(
            e => _mapper.Map<Employee>(e.Employee)).ToList();

        return await Task.FromResult(employeesToReturn);
    }
}