using JsonData.Context;
using ViewData;
using ViewData.ProfileInfo.DTOs;
using ViewData.ProfileInfo.Queries;

namespace JsonData.QueryImpls.ProfileViewQueries;

public class SingleCategoryInfoQuery : IQueryHandler<GetSingleCategoryInfo, CategoryDto>
{

    private readonly JsonDataContext context;


    public SingleCategoryInfoQuery(JsonDataContext context)
    {
        this.context = context;
    }

    public Task<CategoryDto> Query(GetSingleCategoryInfo query)
    {
        throw new NotImplementedException();
    }
}