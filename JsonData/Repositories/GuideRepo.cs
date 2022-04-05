using Application.RepositoryContracts;
using Entities;
using JsonData.DataAccess;

namespace JsonData.Repositories;

public class GuideRepo : IGuideRepo
{

    private readonly JsonDataContext context;

    public GuideRepo(JsonDataContext context)
    {
        this.context = context;
    }

    public Task CreateAsync(Guide guide)
    {
        context.ViaLabData.Guides.Add(guide);
        return Task.CompletedTask;
    }

    public Task<ICollection<Guide>> GetGuidesByCategoryIdAsync(Guid categoryId)
    {
        ICollection<Guide> result = context.ViaLabData.Guides.Where(g => g.CategoryId.Equals(categoryId)).ToList();
        return Task.FromResult(result);
    }

    public Task UpdateAsync(Guide guide)
    {
        Guide first = context.ViaLabData.Guides.First(g => g.Id.Equals(guide.Id));
        first.Update(guide);
        return Task.CompletedTask;
    }

    // public Task<ICollection<Guide>> GetUnCategorizedGuidesByUserId(string teacherName)
    // {
    //     ICollection<Guide> result = context.ViaLabData.Guides.Where(g => g.CategoryId == null && g.OwnerId.Equals(teacherName)).ToList();
    //     return Task.FromResult(result);
    // }
}