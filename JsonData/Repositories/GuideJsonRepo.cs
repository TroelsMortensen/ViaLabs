using Application.RepositoryContracts;
using Domain.Entities;
using Domain.Exceptions;
using JsonData.Context;

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
        context.Guides.Add(guide);
        return Task.CompletedTask;
    }

    public Task<Guide> GetAsync(Guid id)
    {
        Guide? guide = context.Guides.SingleOrDefault(guide => guide.Id.Equals(id));
        if (guide == null)
        {
            throw new NotFoundException($"Guide with id {id} not found!");
        }

        return Task.FromResult(guide);
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

    public Task<ICollection<Guide>> GetByCategoryAsync(Guid id)
    {
        ICollection<Guide> categories = context.Guides.Where(guide => guide.CategoryId.Equals(id)).ToList();
        return Task.FromResult(categories);
    }

}