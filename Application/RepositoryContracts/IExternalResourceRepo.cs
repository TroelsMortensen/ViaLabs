using Entities;

namespace Application.RepositoryContracts;

public interface IExternalResourceRepo
{
    Task CreateAsync(ExternalResource externalResource);
}