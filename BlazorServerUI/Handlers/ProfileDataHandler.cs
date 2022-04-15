using Application.DTOs.CategoryDTOs;
using Application.DTOs.GuideDTOs;
using Application.ProviderContracts;

namespace BlazorServerUI.Handlers;

public class ProfileDataHandler
{
    public CategoriesWithGuideHeadersDto? Categories { get; set; } 

    public Action OnCategoryAdded { get; set; } = null!;
    public Action<Guid> OnCategoryDeleted { get; set; } = null!;
    public Action<GuideHeaderDto> OnGuideAdded { get; set; } = null!;
    
    // TODO public Action< Type { get; set; }  external resource added
    
    private readonly ICategoryProvider categoryProvider;
    
    public ProfileDataHandler(ICategoryProvider categoryProvider)
    {
        this.categoryProvider = categoryProvider;
    }

    public async Task PopulateAsync(string teacher)
    {
        Categories = await categoryProvider.GetCategoriesWithGuideHeadersAsync(teacher);
    }

    public void AddCategory(CategoryDto categoryDto)
    {
        CategoryWithGuidesDto c = new()
        {
            Category = categoryDto
        };
        Categories.CategoriesWithGuides.Add(c);
        OnCategoryAdded?.Invoke();
    }
}