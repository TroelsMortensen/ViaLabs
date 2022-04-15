using Application.DTOs.CategoryDTOs;
using Application.DTOs.GuideDTOs;
using Application.ProviderContracts;
using JsonData.DataAccess;

namespace JsonData.ProviderImpls;

public class JsonCategoryProvider : ICategoryProvider
{
    private readonly JsonDataContext context;

    public JsonCategoryProvider(JsonDataContext context)
    {
        this.context =context;
    }

    public Task<ICollection<CategoryDto>> GetCategoryCardsDTOAsync(string teacherName)
    {
        ICollection<CategoryDto> categoryDtos = context.ViaLabData.Categories.
            Where(c => c.OwnerId.Equals(teacherName)).
            Select(c => new CategoryDto(c.Id, c.Title, c.BackgroundColor)).
            ToList();
        return Task.FromResult(categoryDtos);
    }

    public Task<CategoriesWithGuideHeadersDto> GetCategoriesWithGuideHeadersAsync(string teacher)
    {
        CategoriesWithGuideHeadersDto result = new()
        {
            CategoriesWithGuides = new List<CategoryWithGuidesDto>()
        };
        
        // get all categories for teacher
        ICollection<CategoryDto> categoryDtos = context.ViaLabData.Categories.
            Where(c => c.OwnerId.Equals(teacher)).
            Select(c => new CategoryDto(c.Id, c.Title, c.BackgroundColor)).
            ToList();
        
        // get all guides per category
        foreach (CategoryDto cat in categoryDtos)
        {
            List<GuideHeaderDto> guideHeaderDtos = context.ViaLabData.Guides.
                Where(g => g.CategoryId.Equals(cat.Id)).
                Select(g => new GuideHeaderDto(g.Id, g.Title)).ToList();
            CategoryWithGuidesDto cwg = new();
            cwg.Category = cat;
            cwg.Guides = guideHeaderDtos;
            result.CategoriesWithGuides.Add(cwg);
        }
        
        // get all uncategorized guides for teacher
        CategoryWithGuidesDto unCatCwg = new();
        ICollection<GuideHeaderDto> list = context.ViaLabData.Guides.
            Where(g => g.CategoryId is null && g.OwnerId.Equals(teacher)).
            Select(g => new GuideHeaderDto(g.Id, g.Title)).
            ToList();
        unCatCwg.Guides = list;
        result.CategoriesWithGuides.Add(unCatCwg);

        return Task.FromResult(result);
    }
}