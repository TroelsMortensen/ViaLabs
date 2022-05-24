using Application.RepositoryContracts;
using Entities;
using JsonData.DataAccess;

namespace JsonData.Repositories;

public class ExternalResourceJsonRepo : IExternalResourceRepo
{
    private readonly JsonDataContext context;

    public ExternalResourceJsonRepo(JsonDataContext context)
    {
        this.context = context;
    }

    public Task CreateAsync(ExternalResource externalResource)
    {
        context.ViaLabData.ExternalResources.Add(externalResource);
        return Task.CompletedTask;
    }
}