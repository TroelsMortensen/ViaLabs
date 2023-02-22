using JsonData.Context;
using ViewData;
using ViewData.ProfileInfo.DTOs;
using ViewData.ProfileInfo.Queries;

namespace JsonData.QueryImpls.ProfileViewQueries;

public class SingleCategoryInfoQuery : IQueryHandler<ViewData.ProfileInfo.Queries.SingleCategoryInfoQuery, CategoryDto>
{

    private readonly JsonDataContext context;


    public SingleCategoryInfoQuery(JsonDataContext context)
    {
        this.context = context;
    }

    public Task<CategoryDto> Query(ViewData.ProfileInfo.Queries.SingleCategoryInfoQuery query)
    {
        throw new NotImplementedException();
    }
}