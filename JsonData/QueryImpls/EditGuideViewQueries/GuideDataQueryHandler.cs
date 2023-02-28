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
        return Task.FromResult(new GuideDataVM());
    }
}