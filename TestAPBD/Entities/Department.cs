namespace TestAPBD.Entities;

public class Department
{
    public int DepartmentId { get; set; }
    public string Name { get; set; } = null!;
    public string FacultyBuilding { get; set; } = null!;
    public decimal Budget { get; set; }

    public ICollection<Professor> Professors { get; set; } = new List<Professor>();
}