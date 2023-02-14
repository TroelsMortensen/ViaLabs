using Application.RepositoryContracts;
using Domain.Entities;
using JsonData.Context;

namespace JsonData.Repositories;

internal class ExternalResourceJsonRepo : IExternalResourceRepo
{
    private readonly JsonDataContext context;

    internal ExternalResourceJsonRepo(JsonDataContext context)
    {
        this.context = context;
    }


    public Task AddAsync(ExternalResource externalResource)
    {
        throw new NotImplementedException();
    }

    public Task<ExternalResource> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid dtoId)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<ExternalResource>> GetByCategoryAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}