using JsonData.Context;
using ViewData;
using ViewData.ProfileInfo.DTOs;
using ViewData.ProfileInfo.Queries;

namespace JsonData.QueryImpls.ProfileViewQueries;

public class CategoryInfoByIdQueryHandler : IQueryHandler<CategoryInfoByIdQuery, CategoryDto>
{

    private readonly JsonDataContext context;


    public CategoryInfoByIdQueryHandler(JsonDataContext context)
    {
        this.context = context;
    }

    public Task<CategoryDto> Query(CategoryInfoByIdQuery byIdQuery)
    {
        CategoryDto result = context.Categories.Where(category => category.Id.Equals(byIdQuery.Id))
            .Select(cat => new CategoryDto(cat.Id, cat.Title, cat.BackgroundColor))
            .First();
        return Task.FromResult(result);
    }
}