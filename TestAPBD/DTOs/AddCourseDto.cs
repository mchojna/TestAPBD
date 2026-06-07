using System.ComponentModel.DataAnnotations;

namespace TestAPBD.DTOs;

public class AddCourseDto
{
    [Required] [MaxLength(100)] public string Title { get; set; } = null!;

    [Required] [Range(1, int.MaxValue)] public int Credits { get; set; }

    [Required] [Range(1, int.MaxValue)] public int Semester { get; set; }

    [Required] public string ProfessorsLastName { get; set; } = null!;

    [Required] [MinLength(1)] public IEnumerable<int> Students { get; set; } = [];
}