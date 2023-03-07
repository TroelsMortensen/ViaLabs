using Domain.Exceptions;
using JsonData.Context;
using ViewData;
using ViewData.ProfileInfo.DTOs;
using ViewData.ProfileInfo.Queries;

namespace JsonData.QueryImpls.EditGuideViewQueries;

public class SlideStepQueryHandler : IQueryHandler<SingleSlideStepQuery, SlideStepVM>
{
    private readonly JsonDataContext context;

    public SlideStepQueryHandler(JsonDataContext context)
    {
        this.context = context;
    }

    public Task<SlideStepVM> Query(SingleSlideStepQuery query)
    {
        SlideStepVM? slideStepVm = context.Guides
            .SelectMany(guide => guide.Slides)
            // .Where(step => step.Id.Equals(query.SlideStepId))
            .Select(step => new SlideStepVM
            {
                Id = step.Id,
                Index = step.StepIndex,
                Title = step.Title,
                ContentId = step.SlideContentId
            }).SingleOrDefault(vm => vm.ContentId.Equals(query.SlideStepId));

        if (slideStepVm == null)
        {
            throw new NotFoundException($"Slide step with ID {query.SlideStepId} was not found");
        }

        return Task.FromResult(slideStepVm);
    }
}