using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAPBD.Entities;

namespace TestAPBD.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.CourseId);
        builder.Property(c => c.Title).HasMaxLength(100).IsRequired();
        builder.Property(c => c.Credits).IsRequired();
        builder.Property(c => c.Semester).IsRequired();

        builder.HasOne(c => c.Professor)
            .WithMany(p => p.Courses)
            .HasForeignKey(c => c.ProfessorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
            new Course { CourseId = 1, Title = "Database Systems", Credits = 5, Semester = 1, ProfessorId = 1 },
            new Course { CourseId = 2, Title = "Algorithms", Credits = 4, Semester = 2, ProfessorId = 1 },
            new Course { CourseId = 3, Title = "Calculus", Credits = 3, Semester = 2, ProfessorId = 2 },
            new Course { CourseId = 4, Title = "Linear Algebra", Credits = 4, Semester = 3, ProfessorId = 2 },
            new Course { CourseId = 5, Title = "Data Structures", Credits = 5, Semester = 1, ProfessorId = 1 }
        );
    }
}