using Application.RepositoryContracts;
using Domain.Entities;
using JsonData.Context;

namespace JsonData.Repositories;

public class SlideContentJsonRepo: ISlideContentRepo
{

    private readonly JsonDataContext context;

    public SlideContentJsonRepo(JsonDataContext context)
    {
        this.context = context;
    }

    public Task CreateAsync(SlideContent slideContent)
    {
        context.SlideContents.Add(slideContent);
        return Task.CompletedTask;
    }

    public Task<SlideDetails> GetAsync(Guid slideContentId)
    {
        throw new NotImplementedException();
    }
}