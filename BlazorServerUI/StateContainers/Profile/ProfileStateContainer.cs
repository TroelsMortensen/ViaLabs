using ViewData;
using ViewData.ProfileInfo.DTOs;
using ViewData.ProfileInfo.Queries;

namespace BlazorServerUI.StateContainers.Profile;

public class ProfileStateContainer
{
    public ICollection<CategoryWithGuidesAndResourcesDto> CategoriesWithGuidesAndResources { get; set; } = null!;

    public Action OnCategoryAdded { get; set; } = null!;
    public Action OnCategoryDeleted { get; set; } = null!;
    public Action<Guid?> OnGuideAdded { get; set; } = null!;
    public Action<Guid?> OnExtResourceAdded { get; set; } = null!;
    public Action<Guid?> OnExtResourceUpdated { get; set; } = null!;
    public Action<Guid?> OnCategoryUpdated { get; set; } = null!;

    // TODO public Action< Type { get; set; }  external resource added

    private readonly IQueryHandler<ProfileInfoOverviewQuery, ICollection<CategoryWithGuidesAndResourcesDto>> categoryOverviewDataProvider;

    public ProfileStateContainer(IQueryHandler<ProfileInfoOverviewQuery, ICollection<CategoryWithGuidesAndResourcesDto>> categoryOverviewDataProvider)
    {
        this.categoryOverviewDataProvider = categoryOverviewDataProvider;
    }

    public async Task PopulateAsync(string teacher)
    {
        CategoriesWithGuidesAndResources = await categoryOverviewDataProvider.Query(new ProfileInfoOverviewQuery(teacher));
    }

    public void AddCategory(CategoryDto categoryDto)
    {
        CategoryWithGuidesAndResourcesDto c = new(categoryDto, new List<GuideHeaderDto>(), new List<ExternalResourceDisplayDto>());
        
        CategoriesWithGuidesAndResources.Add(c);
        OnCategoryAdded?.Invoke();
    }

    public void AddGuideToCategory(GuideHeaderDto created, CategoryDto? category)
    {
        CategoryWithGuidesAndResourcesDto cwgw = category != null
            ? CategoriesWithGuidesAndResources.First(c => c.Category != null && c.Category!.Id.Equals(category.Id))
            : CategoriesWithGuidesAndResources.First(c => c.Category == null);

        cwgw.Guides.Add(created);
        OnGuideAdded?.Invoke(category?.Id);
    }

    public void DeleteCategory(Guid categoryId)
    {
        CategoryWithGuidesAndResourcesDto cwgw = CategoriesWithGuidesAndResources.First(c => c.Category.Id.Equals(categoryId));
        // ICollection<GuideHeaderDto> guideHeaderDtos = cwgw.Guides;
        // ICollection<ExternalResourceDisplayDto> exResDtos = cwgw.ExternalResources;

        CategoriesWithGuidesAndResources.Remove(cwgw);
        // CategoryWithGuidesAndResourcesDto uncategorized = CategoriesWithGuidesAndResources.First(c => c.Category == null);
        //
        // foreach (GuideHeaderDto dto in guideHeaderDtos)
        // {
        //     uncategorized.Guides.Add(dto);
        // }
        //
        // foreach (ExternalResourceDisplayDto dto in exResDtos)
        // {
        //     uncategorized.ExternalResources.Add(dto);
        // }

        OnCategoryDeleted.Invoke();
    }

    public void AddExternalResourceToCategory(ExternalResourceDisplayDto created, CategoryDto? category)
    {
        CategoryWithGuidesAndResourcesDto cwgw = category != null
            ? CategoriesWithGuidesAndResources.First(c => c.Category != null && c.Category!.Id.Equals(category.Id))
            : CategoriesWithGuidesAndResources.First(c => c.Category == null);


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

    public void UpdateCategory(Guid categoryDtoId)
    {
        OnCategoryUpdated.Invoke(categoryDtoId);
    }
}