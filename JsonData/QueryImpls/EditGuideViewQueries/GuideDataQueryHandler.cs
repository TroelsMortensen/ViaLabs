using Domain.Exceptions;
using JsonData.Context;
using ViewData;
using ViewData.ProfileInfo.DTOs;
using ViewData.ProfileInfo.Queries;

namespace JsonData.QueryImpls.EditGuideViewQueries;

public class GuideDataQueryHandler : IQueryHandler<GuideDataForEditQuery, GuideDataVM>
{
    private readonly JsonDataContext context;

    public GuideDataQueryHandler(JsonDataContext context)
    {
        this.context = context;
    }

    public Task<GuideDataVM> Query(GuideDataForEditQuery query)
    {
        GuideDataVM? guideData = context.Guides
            .Where(guide => guide.Id.Equals(query.Id))
            .Select(guide => new GuideDataVM
            {
                GuideId = guide.Id,
                Title = guide.Title,
                CategoryId = guide.CategoryId,
                Description = guide.Description,
                StepNumbersVisible = guide.IsDisplayingStepNums,
                Slides = guide.Slides,
                CategoriesByTeacher = context
                    .Categories
                    .Where(category => category.Owner.Equals(guide.TeacherId))
                    .Select(category => new CategoryVM(category.Id, category.Title, category.BackgroundColor))
                    .ToList()
            }).SingleOrDefault(vm => vm.GuideId.Equals(query.Id));
        if (guideData == null)
        {
            throw new NotFoundException($"Could not find guide with ID {query.Id}");
        }

        return Task.FromResult(guideData);
    }
}