﻿namespace HCM.Domain.Abstractions.Models;

public class Course : Model
{
    public string Name { get; set; } = string.Empty;
    public List<EmployeeCourse> EmployeeCourses { get; set; } = new();
}