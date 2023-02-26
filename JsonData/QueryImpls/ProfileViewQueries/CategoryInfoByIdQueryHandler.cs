using JsonData.Context;
using ViewData;
using ViewData.ProfileInfo.DTOs;
using ViewData.ProfileInfo.Queries;

namespace JsonData.QueryImpls.ProfileViewQueries;

public class CategoryInfoByIdQueryHandler : IQueryHandler<CategoryInfoByIdQuery, CategoryVM>
{

    private readonly JsonDataContext context;


    public CategoryInfoByIdQueryHandler(JsonDataContext context)
    {
        this.context = context;
    }

    public Task<CategoryVM> Query(CategoryInfoByIdQuery byIdQuery)
    {
        CategoryVM result = context.Categories.Where(category => category.Id.Equals(byIdQuery.Id))
            .Select(cat => new CategoryVM(cat.Id, cat.Title, cat.BackgroundColor))
            .First();
        return Task.FromResult(result);
    }
}