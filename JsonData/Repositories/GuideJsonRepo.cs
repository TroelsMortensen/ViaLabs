using Application.RepositoryContracts;
using Domain.Models;
using JsonData.Context;

namespace JsonData.Repositories;

public class GuideJsonRepo : IGuideRepo
{
    private readonly CollectionsDataContext context;

    public GuideJsonRepo(CollectionsDataContext context)
    {
        this.context = context;
    }

    public Task CreateAsync(Guide guide)
    {
        context.Guides.Add(guide);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Guide guide)
    {
        Guide first = context.Guides.First(g => g.Id.Equals(guide.Id));
        first.Update(guide);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        int removedCount = context.Guides.ToList().RemoveAll(g => g.Id.Equals(id));
        if (removedCount == 0)
        {
            throw new Exception("Nothing was removed, due to some error");
        }
        return Task.CompletedTask;
    }

    // public Task UnParentGuidesFromCategory(Guid categoryId)
    // {
    //     context.Guides.Where(g => g.CategoryId.Equals(categoryId)).ToList().ForEach(guide => guide.DetachFromCategory());
    //
    //     return Task.CompletedTask;
    // }

}