using Application.Features.CategoryOverview;
using Application.Features.ProfileDataLogic.DTOs.CategoryDTOs;
using Application.Features.ProfileDataLogic.DTOs.ExternalResourceDTOs;
using Application.Features.ProfileDataLogic.DTOs.GuideDTOs;
using Application.Features.ProfileDataLogic.ProviderContracts;

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

    private readonly ICategoryOverviewDataProvider categoryOverviewDataProvider;

    public ProfileStateContainer(ICategoryOverviewDataProvider categoryOverviewDataProvider)
    {
        this.categoryOverviewDataProvider = categoryOverviewDataProvider;
    }

    public async Task PopulateAsync(string teacher)
    {
        // CategoriesWithGuides = await categoryProvider.GetCategoriesWithGuideHeadersByTeacherAsync(teacher); TODO
    }

    public void AddCategory(CategoryDto categoryDto)
    {
        throw new NotImplementedException();
        // CategoryWithGuidesAndResourcesDto c = new()
        // {
        //     Category = categoryDto,
        //     Guides = new List<GuideHeaderDto>(),
        //     ExternalResources = new List<ExternalResourceDisplayDto>()
        // };
        // CategoriesWithGuides.Add(c);
        // OnCategoryAdded?.Invoke();
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
        ICollection<ExternalResourceDisplayDto> exResDtos = cwgw.ExternalResources;
        CategoriesWithGuides.Remove(cwgw);
        CategoryWithGuidesAndResourcesDto uncategorized = CategoriesWithGuides.First(c => c.Category == null);

        foreach (GuideHeaderDto dto in guideHeaderDtos)
        {
            uncategorized.Guides.Add(dto);
        }

        foreach (ExternalResourceDisplayDto dto in exResDtos)
        {
            uncategorized.ExternalResources.Add(dto);
        }

        OnCategoryDeleted.Invoke();
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
        throw new NotImplementedException();
        // CategoryWithGuidesAndResourcesDto cwgar =
        //     CategoriesWithGuides.First(dto => dto.ExternalResources.Any(extRes => extRes.Id.Equals(resource.Id)));
        // ExternalResourceDisplayDto toUpdate = cwgar.ExternalResources.First(extRes => extRes.Id.Equals(resource.Id));
        // toUpdate.Title = resource.Title;
        // toUpdate.Description = resource.Description;
        // toUpdate.Url = resource.Url;
        // OnExtResourceUpdated?.Invoke(cwgar.Category?.Id);
        
    }

    public void DeleteResource(Guid id)
    {
        throw new NotImplementedException();
    }
}