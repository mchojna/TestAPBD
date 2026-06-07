using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAPBD.Entities;

namespace TestAPBD.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.StudentId);
        builder.Property(s => s.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(s => s.LastName).HasMaxLength(100).IsRequired();
        builder.Property(s => s.Email).HasMaxLength(100).IsRequired();
        builder.Property(s => s.EnrollmentYear).IsRequired();

        builder.HasData(
            new Student
            {
                StudentId = 1, FirstName = "John", LastName = "Wick",
                Email = "john.wick@student.edu", EnrollmentYear = 2022
            },
            new Student
            {
                StudentId = 2, FirstName = "Anna", LastName = "Kowalska",
                Email = "anna.kowalska@student.edu", EnrollmentYear = 2023
            },
            new Student
            {
                StudentId = 3, FirstName = "Peter", LastName = "Nowak",
                Email = "peter.nowak@student.edu", EnrollmentYear = 2021
            }
        );
    }
}