using Domain.Exceptions;
using JsonData.Context;
using ViewData;
using ViewData.ProfileInfo.DTOs;
using ViewData.ProfileInfo.Queries;

namespace JsonData.QueryImpls.EditGuideViewQueries;

public class SlideQueryHandler : IQueryHandler<SingleSlideQuery, SlideVM>
{
    private readonly JsonDataContext context;

    public SlideQueryHandler(JsonDataContext context)
    {
        this.context = context;
    }

    public Task<SlideVM> Query(SingleSlideQuery query)
    {
        SlideVM? slideVm = context.Guides
            .SelectMany(guide => guide.Slides)
            // .Where(step => step.Id.Equals(query.SlideStepId))
            .Select(step => new SlideVM
            {
                Id = step.Id,
                Index = step.StepIndex,
                Title = step.Title,
                ContentId = step.SlideContentId
            }).SingleOrDefault(vm => vm.Id.Equals(query.SlideId));

        if (slideVm == null)
        {
            throw new NotFoundException($"Slide step with ID {query.SlideId} was not found");
        }

        return Task.FromResult(slideVm);
    }
}