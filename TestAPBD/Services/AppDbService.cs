using Microsoft.EntityFrameworkCore;
using TestAPBD.Data;
using TestAPBD.DTOs;
using TestAPBD.Entities;
using TestAPBD.Exceptions;

namespace TestAPBD.Services;

public class AppDbService(AppDbContext appDbContext) : IAppDbService
{
    public async Task<IEnumerable<GetProfessorDto>> GetProfessorsAsync(string? lastName)
    {
        var query = appDbContext.Professors
            .Include(p => p.Department)
            .Include(p => p.Courses)
            .ThenInclude(c => c.Enrollments)
            .ThenInclude(e => e.Student)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(lastName))
            query = query.Where(p => EF.Functions.Like(p.LastName, $"%{lastName}%"));

        var professors = await query.ToListAsync();

        return professors.Select(p => new GetProfessorDto
        {
            ProfessorId = p.ProfessorId,
            FirstName = p.FirstName,
            LastName = p.LastName,
            Email = p.Email,
            Name = p.Department.Name,
            Courses = p.Courses.Select(c => new GetProfessorCourseDto
            {
                CourseId = c.CourseId,
                Title = c.Title,
                Credits = c.Credits,
                Semester = c.Semester,
                Enrollments = c.Enrollments.Select(e => new GetCourseEnrollmentDto
                {
                    Grade = e.Grade,
                    Status = e.Status,
                    Student = new GetEnrollmentStudentDto
                    {
                        StudentId = e.Student.StudentId,
                        FirstName = e.Student.FirstName,
                        LastName = e.Student.LastName,
                        Email = e.Student.Email,
                        EnrollmentYear = e.Student.EnrollmentYear
                    }
                }).ToList()
            }).ToList()
        }); 
        // TODO: Throw exception when result list is empty :) 
    }

    public async Task AddCourseAsync(AddCourseDto dto)
    {
        await using var transaction = await appDbContext.Database.BeginTransactionAsync();

        var professor = await appDbContext.Professors
                            .FirstOrDefaultAsync(p => p.LastName == dto.ProfessorsLastName)
                        ?? throw new NotFoundException($"Professor '{dto.ProfessorsLastName}' not found.");

        var course = new Course
        {
            Title = dto.Title,
            Credits = dto.Credits,
            Semester = dto.Semester,
            ProfessorId = professor.ProfessorId
        };

        await appDbContext.Courses.AddAsync(course);
        await appDbContext.SaveChangesAsync();

        foreach (var studentId in dto.Students)
        {
            var studentExists = await appDbContext.Students.AnyAsync(s => s.StudentId == studentId);
            if (!studentExists) throw new NotFoundException($"Student '{studentId}' not found.");

            var enrollment = new Enrollment
            {
                CourseId = course.CourseId,
                StudentId = studentId,
                Status = "Enrolled"
            };

            await appDbContext.Enrollments.AddAsync(enrollment);
        }

        await appDbContext.SaveChangesAsync();
        await transaction.CommitAsync();
    }
}