using Domain.Models;

namespace Application.RepositoryContracts;

public interface IExternalResourceRepo
{
    Task CreateAsync(ExternalResource externalResource);
    Task UpdateAsync(ExternalResource edited);
    Task UnParentResourcesFromCategory(Guid categoryId);
    Task DeleteAsync(Guid id);
}