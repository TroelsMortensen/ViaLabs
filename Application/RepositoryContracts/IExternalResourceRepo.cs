using Domain.Entities;

namespace Application.RepositoryContracts;

public interface IExternalResourceRepo
{
    Task AddAsync(ExternalResource externalResource);
    Task<ExternalResource> GetAsync(Guid id);
    Task DeleteAsync(Guid id);
    Task<ICollection<ExternalResource>> GetByCategoryAsync(Guid id);
}