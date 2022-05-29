using Application.DTOs.CategoryDTOs;
using Application.DTOs.ExternalResourceDTOs;
using Application.DTOs.GuideDTOs;
using Application.ProviderContracts;

namespace BlazorServerUI.StateContainers.Profile;

public class ProfileStateContainer
{
    public ICollection<CategoryWithGuidesAndResourcesDto> CategoriesWithGuides { get; set; } = null!;

    public Action OnCategoryAdded { get; set; } = null!;
    public Action OnCategoryDeleted { get; set; } = null!;
    public Action<Guid?> OnGuideAdded { get; set; } = null!;
    public Action<Guid?> OnExtResourceAdded { get; set; } = null!;
    public Action<Guid?> OnExtResourceUpdated { get; set; } = null!;
    public Action<Guid?> OnCategoryUpdated { get; set; } = null!;

    // TODO public Action< Type { get; set; }  external resource added

    private readonly ICategoryProvider categoryProvider;

    public ProfileStateContainer(ICategoryProvider categoryProvider)
    {
        this.categoryProvider = categoryProvider;
    }

    public async Task PopulateAsync(string teacher)
    {
        CategoriesWithGuides = await categoryProvider.GetCategoriesWithGuideHeadersAsync(teacher);
    }

    public void AddCategory(CategoryDto categoryDto)
    {
        CategoryWithGuidesAndResourcesDto c = new()
        {
            Category = categoryDto
        };
        CategoriesWithGuides.Add(c);
        OnCategoryAdded?.Invoke();
    }

    public void AddGuideToCategory(GuideHeaderDto created, CategoryDto? category)
    {
        CategoryWithGuidesAndResourcesDto cwgw = category != null
            ? CategoriesWithGuides.First(c => c.Category != null && c.Category!.Id.Equals(category.Id))
            : CategoriesWithGuides.First(c => c.Category == null);

        cwgw.Guides.Add(created);
        OnGuideAdded?.Invoke(category?.Id);
    }

    public void DeleteCategory(Guid categoryId)
    {
        CategoryWithGuidesAndResourcesDto cwgw = CategoriesWithGuides.First(c => c.Category != null && c.Category!.Id.Equals(categoryId));
        ICollection<GuideHeaderDto> guideHeaderDtos = cwgw.Guides;
        CategoriesWithGuides.Remove(cwgw);
        CategoryWithGuidesAndResourcesDto uncategorized = CategoriesWithGuides.First(c => c.Category == null);
        foreach (GuideHeaderDto dto in guideHeaderDtos)
        {
            uncategorized.Guides.Add(dto);
        }
        OnCategoryDeleted.Invoke();
        throw new Exception("Updater så resources også bliver håndteret");
    }

    public void AddExternalResourceToCategory(ExternalResourceDisplayDto created, CategoryDto? category)
    {
        CategoryWithGuidesAndResourcesDto cwgw = category != null
            ? CategoriesWithGuides.First(c => c.Category != null && c.Category!.Id.Equals(category.Id))
            : CategoriesWithGuides.First(c => c.Category == null);

        
        cwgw.ExternalResources.Add(created);
        OnExtResourceAdded?.Invoke(category?.Id);
    }

    public void UpdateResource(ExternalResourceDisplayDto resource)
    {
        CategoryWithGuidesAndResourcesDto cwgar = CategoriesWithGuides.First(dto => dto.ExternalResources.Any(extRes => extRes.Id.Equals(resource.Id)));
        ExternalResourceDisplayDto toUpdate = cwgar.ExternalResources.First(extRes => extRes.Id.Equals(resource.Id));
        toUpdate.Title = resource.Title;
        toUpdate.Description = resource.Description;
        toUpdate.Url = resource.Url;
        OnExtResourceUpdated?.Invoke(cwgar.Category?.Id);
    }
}