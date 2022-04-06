using Application.DTOs.CategoryDTOs;
using Application.ProviderContracts;
using Application.RepositoryContracts;
using JsonData.DataAccess;

namespace JsonData.ProviderImpls;

public class JsonCategoryProvider : ICategoryProvider
{
    private readonly JsonDataContext context;

    public JsonCategoryProvider(IDbContext context)
    {
        this.context = (JsonDataContext)context;
    }

    public Task<ICollection<CategoryDto>> GetCategoryCardsDTOAsync(string teacherName)
    {
        ICollection<CategoryDto> categoryDtos = context.ViaLabData.Categories.
            Where(c => c.OwnerId.Equals(teacherName)).
            Select(c => new CategoryDto(c.Id, c.Title, c.BackgroundColor)).
            ToList();
        return Task.FromResult(categoryDtos);
    }
}