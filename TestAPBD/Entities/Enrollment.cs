namespace TestAPBD.Entities;

public class Enrollment
{
    public int CourseId { get; set; }
    public int StudentId { get; set; }
    public decimal? Grade { get; set; }
    public string Status { get; set; } = null!;

    public Course Course { get; set; } = null!;
    public Student Student { get; set; } = null!;
}