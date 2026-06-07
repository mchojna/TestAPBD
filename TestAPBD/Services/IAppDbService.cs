using TestAPBD.DTOs;

namespace TestAPBD.Services;

public interface IAppDbService
{
    Task<IEnumerable<GetProfessorDto>> GetProfessorsAsync(string? lastName);
    Task AddCourseAsync(AddCourseDto dto);
}