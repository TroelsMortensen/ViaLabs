using Application.DTOs.CategoryDTOs;
using Application.Providers;
using JsonData.DataAccess;

namespace JsonData.ProviderImpls;

public class JsonCategoryProvider : ICategoryProvider
{
    private JsonDataContext context;

    public JsonCategoryProvider(JsonDataContext context)
    {
        this.context = context;
    }

    public Task<List<CategoryDto>> GetCategoryCardsDTOAsync(string teacherName)
    {
        List<CategoryDto> categoryDtos = context.ViaLabData.Categories.Where(c => c.OwnerId.Equals(teacherName)).Select(c => new CategoryDto
        {
            Id = c.Id,
            Title = c.Title,
            BackgroundColor = c.BackgroundColor
        }).ToList();
        return Task.FromResult(categoryDtos);
    }
}