namespace TestAPBD.Entities;

public class Course
{
    public int CourseId { get; set; }
    public string Title { get; set; } = null!;
    public int Credits { get; set; }
    public int Semester { get; set; }
    public int ProfessorId { get; set; }

    public Professor Professor { get; set; } = null!;
    public ICollection<Enrollment> Enrollments { get; set; } = [];
}