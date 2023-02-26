using Domain.Exceptions;
using JsonData.Context;
using ViewData;
using ViewData.ProfileInfo.DTOs;
using ViewData.ProfileInfo.Queries;

namespace JsonData.QueryImpls.ProfileViewQueries;

public class GuideHeaderDtoQueryHandler : IQueryHandler<GuideHeaderQuery, GuideHeaderDto>
{
    private readonly JsonDataContext context;

    public GuideHeaderDtoQueryHandler(JsonDataContext context)
    {
        this.context = context;
    }

    public Task<GuideHeaderDto> Query(GuideHeaderQuery query)
    {
        GuideHeaderDto? guideHeader = context.Guides
            .Select(guide => new GuideHeaderDto(guide.Id, guide.Title))
            .FirstOrDefault(dto => dto.Id.Equals(query.Id));
        if (guideHeader == null)
        {
            throw new NotFoundException($"Could not find guide with ID {query.Id}.");
        }

        return Task.FromResult(guideHeader);
    }
}