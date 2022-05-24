using Entities;

namespace Application.RepositoryContracts;

public interface IGuideRepo
{
    Task CreateAsync(Guide guide);
    Task UpdateAsync(Guide guide);
    Task DeleteAsync(Guid id);
    Task UnParentGuidesFromCategory(Guid categoryId); // TODO this functionality should be moved to the repo impl
}