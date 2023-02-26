using Domain.Exceptions;
using JsonData.Context;
using ViewData;
using ViewData.ProfileInfo.DTOs;
using ViewData.ProfileInfo.Queries;

namespace JsonData.QueryImpls.ProfileViewQueries;

public class GuideHeaderDtoQueryHandler : IQueryHandler<GuideHeaderQuery, GuideHeaderVM>
{
    private readonly JsonDataContext context;

    public GuideHeaderDtoQueryHandler(JsonDataContext context)
    {
        this.context = context;
    }

    public Task<GuideHeaderVM> Query(GuideHeaderQuery query)
    {
        GuideHeaderVM? guideHeader = context.Guides
            .Select(guide => new GuideHeaderVM(guide.Id, guide.Title))
            .FirstOrDefault(dto => dto.Id.Equals(query.Id));
        if (guideHeader == null)
        {
            throw new NotFoundException($"Could not find guide with ID {query.Id}.");
        }

        return Task.FromResult(guideHeader);
    }
}