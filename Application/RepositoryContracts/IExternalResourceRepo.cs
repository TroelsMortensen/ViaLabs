using Domain.Models;

namespace Application.RepositoryContracts;

public interface IExternalResourceRepo
{
    Task AddToCategory(ExternalResource externalResource, Guid categoryId);
    Task UpdateAsync(ExternalResource edited);
    // Task UnParentResourcesFromCategory(Guid categoryId);
    Task DeleteAsync(Guid id);
}