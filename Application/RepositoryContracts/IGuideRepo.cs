using Entities;

namespace Application.RepositoryContracts;

public interface IGuideRepo
{
    Task CreateAsync(Guide guide);
    Task UpdateAsync(Guide guide);
    Task DeleteGuide(Guid id);
    Task UnParentGuidesFromCategory(Guid categoryId);
}