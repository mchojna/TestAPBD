namespace TestAPBD.DTOs;

public class GetProfessorDto
{
    public int ProfessorId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
    public IEnumerable<GetProfessorCourseDto> Courses { get; set; } = [];
}

public class GetProfessorCourseDto
{
    public int CourseId { get; set; }
    public string Title { get; set; } = null!;
    public int Credits { get; set; }
    public int Semester { get; set; }
    public IEnumerable<GetCourseEnrollmentDto> Enrollments { get; set; } = [];
}

public class GetCourseEnrollmentDto
{
    public decimal? Grade { get; set; }
    public string Status { get; set; } = null!;
    public GetEnrollmentStudentDto Student { get; set; } = null!;
}

public class GetEnrollmentStudentDto
{
    public int StudentId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int EnrollmentYear { get; set; }
}