using Application.RepositoryContracts;
using Domain.Models;
using JsonData.Context;

namespace JsonData.Repositories;

public class ExternalResourceJsonRepo : IExternalResourceRepo
{
    private readonly JsonDataContext context;

    public ExternalResourceJsonRepo(JsonDataContext context)
    {
        this.context = context;
    }


    public Task AddToCategory(ExternalResource externalResource, Guid categoryId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(ExternalResource edited)
    {
        ExternalResource first = context.ExternalResources.First(resource => resource.Id.Equals(edited.Id));
        // TODO delete, then add
        first.Update(edited.Title, edited.Description, edited.Url);
        throw new NotImplementedException("not done yet");
        return Task.CompletedTask;
    }

    // public Task UnParentResourcesFromCategory(Guid categoryId)
    // {
    //     context.ExternalResources
    //         .Where(er => er.CategoryId.Equals(categoryId))
    //         .ToList()
    //         .ForEach(er => er.DetachFromCategory());
    //
    //     return Task.CompletedTask;
    // }

    public Task DeleteAsync(Guid dtoId)
    {
        throw new NotImplementedException();
    }
}