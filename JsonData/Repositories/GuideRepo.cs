using Application.Repositories;
using Entities;

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
        context.SaveChanges();
        return Task.CompletedTask;
    }

    public Task<ICollection<Guide>> GetGuidesByCategoryIdAsync(Guid categoryId)
    {
        ICollection<Guide> result = context.ViaLabData.Guides.Where(g => g.CategoryId.Equals(categoryId)).ToList();
        return Task.FromResult(result);
    }

    public Task<ICollection<Guide>> GetUnCategorizedGuidesByUserId(string teacherName)
    {
        ICollection<Guide> result = context.ViaLabData.Guides.Where(g => g.CategoryId == null && g.OwnerId.Equals(teacherName)).ToList();
        return Task.FromResult(result);
    }
}