using Application.Repositories;
using Entities;

namespace JsonData.Repositories;

public class GuideRepo : IGuideRepo
{

    private JsonDataContext context;

    public GuideRepo(JsonDataContext context)
    {
        this.context = context;
    }

    public Task CreateAsync(Guide guide)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Guide>> GetGuidesByCategoryIdAsync(Guid categoryId)
    {
        ICollection<Guide> result = new List<Guide>();
        return Task.FromResult(result);
    }
}