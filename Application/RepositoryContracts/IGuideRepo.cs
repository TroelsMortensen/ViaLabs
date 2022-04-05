using Entities;

namespace Application.RepositoryContracts;

public interface IGuideRepo
{
    Task CreateAsync(Guide guide);
    Task<ICollection<Guide>> GetGuidesByCategoryIdAsync(Guid categoryId);
    Task UpdateAsync(Guide guide);
}