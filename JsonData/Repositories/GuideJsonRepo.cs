using Application.RepositoryContracts;
using Domain.Models;
using JsonData.DataAccess;

namespace JsonData.Repositories;

public class GuideJsonRepo : IGuideRepo
{
    private readonly JsonDataContext context;

    public GuideJsonRepo(JsonDataContext context)
    {
        this.context = context;
    }

    public Task CreateAsync(Guide guide)
    {
        context.ViaLabData.Guides.Add(guide);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Guide guide)
    {
        Guide first = context.ViaLabData.Guides.First(g => g.Id.Equals(guide.Id));
        first.Update(guide);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        int removedCount = context.ViaLabData.Guides.ToList().RemoveAll(g => g.Id.Equals(id));
        if (removedCount == 0)
        {
            throw new Exception("Nothing was removed, due to some error");
        }
        return Task.CompletedTask;
    }

    public Task UnParentGuidesFromCategory(Guid categoryId)
    {
        context.ViaLabData.Guides.Where(g => g.CategoryId.Equals(categoryId)).ToList().ForEach(guide => guide.CategoryId = null);

        return Task.CompletedTask;
    }

}