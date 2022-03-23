using Entities;

namespace Application.RepositoryContracts;

public interface IGuideRepo
{
    Task CreateAsync(Guide guide);
    Task<ICollection<Guide>> GetGuidesByCategoryIdAsync(Guid categoryId);
    Task<ICollection<Guide>> GetUnCategorizedGuidesByUserId(string teacherName);
}