namespace TestAPBD.Entities;

public class Professor
{
    public int ProfessorId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int DepartmentId { get; set; }

    public Department Department { get; set; } = null!;
    public ICollection<Course> Courses { get; set; } = [];
}