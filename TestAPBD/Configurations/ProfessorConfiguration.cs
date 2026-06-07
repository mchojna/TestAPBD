using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAPBD.Entities;

namespace TestAPBD.Configurations;

public class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
{
    public void Configure(EntityTypeBuilder<Professor> builder)
    {
        builder.HasKey(p => p.ProfessorId);
        builder.Property(p => p.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(p => p.LastName).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Email).HasMaxLength(100).IsRequired();

        builder.HasOne(p => p.Department)
            .WithMany(d => d.Professors)
            .HasForeignKey(p => p.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
            new Professor
            {
                ProfessorId = 1, FirstName = "Alice", LastName = "Johnson",
                Email = "alice.johnson@university.edu", DepartmentId = 1
            },
            new Professor
            {
                ProfessorId = 2, FirstName = "Robert", LastName = "Smith",
                Email = "robert.smith@university.edu", DepartmentId = 2
            },
            new Professor
            {
                ProfessorId = 3, FirstName = "Maria", LastName = "Williams",
                Email = "maria.williams@university.edu", DepartmentId = 3
            }
        );
    }
}