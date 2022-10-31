using Application.RepositoryContracts;
using Domain.Models;
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

    public Task UpdateAsync(ExternalResource edited)
    {
        ExternalResource first = context.ViaLabData.ExternalResources.First(resource => resource.Id.Equals(edited.Id));
        first.Title = edited.Title;
        first.Description = edited.Description;
        first.Url = edited.Url;
        return Task.CompletedTask;
    }

    public Task UnParentResourcesFromCategory(Guid categoryId)
    {
        context.ViaLabData.ExternalResources
            .Where(er => er.CategoryId.Equals(categoryId))
            .ToList()
            .ForEach(er => er.CategoryId = null);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid dtoId)
    {
        throw new NotImplementedException();
    }
}