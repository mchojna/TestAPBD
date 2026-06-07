using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAPBD.Entities;

namespace TestAPBD.Configurations;

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.HasKey(e => new { e.CourseId, e.StudentId });
        builder.Property(e => e.Grade).HasColumnType("decimal(2,1)");
        builder.Property(e => e.Status).HasMaxLength(100).IsRequired();

        builder.HasOne(e => e.Course)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
            new Enrollment { CourseId = 1, StudentId = 1, Grade = 4.5m, Status = "Completed" },
            new Enrollment { CourseId = 1, StudentId = 2, Grade = 3.5m, Status = "Completed" },
            new Enrollment { CourseId = 5, StudentId = 1, Grade = 4.8m, Status = "Completed" },
            new Enrollment { CourseId = 5, StudentId = 3, Grade = 4.2m, Status = "Completed" },
            new Enrollment { CourseId = 2, StudentId = 2, Grade = 3.0m, Status = "Completed" }
        );
    }
}