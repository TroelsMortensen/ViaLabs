using JsonData.Context;
using ViewData;
using ViewData.ProfileInfo.DTOs;
using ViewData.ProfileInfo.Queries;

namespace JsonData.QueryImpls.ProfileViewQueries;

public class SingleCategoryInfoQueryHandler : IQueryHandler<SingleCategoryInfoQuery, CategoryDto>
{

    private readonly JsonDataContext context;


    public SingleCategoryInfoQueryHandler(JsonDataContext context)
    {
        this.context = context;
    }

    public Task<CategoryDto> Query(SingleCategoryInfoQuery query)
    {
        throw new NotImplementedException();
    }
}