using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAPBD.Entities;

namespace TestAPBD.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(d => d.DepartmentId);
        builder.Property(d => d.Name).HasMaxLength(100).IsRequired();
        builder.Property(d => d.FacultyBuilding).HasMaxLength(100).IsRequired();
        builder.Property(d => d.Budget).HasColumnType("decimal(10,2)").IsRequired();

        builder.HasData(
            new Department { DepartmentId = 1, Name = "Computer Science", FacultyBuilding = "A", Budget = 1000000 },
            new Department { DepartmentId = 2, Name = "Mathematics", FacultyBuilding = "B", Budget = 800000 },
            new Department { DepartmentId = 3, Name = "Physics", FacultyBuilding = "C", Budget = 900000 }
        );
    }
}