using Application.Features.ProfileDataLogic.DTOs.CategoryDTOs;
using Application.Features.ProfileDataLogic.DTOs.ExternalResourceDTOs;
using Application.Features.ProfileDataLogic.DTOs.GuideDTOs;
using Application.Features.ProfileDataLogic.ProviderContracts;
using JsonData.Context;

namespace JsonData.ProviderImpls.ProfileProviderImpls;

public class JsonCategoryProvider : ICategoryProvider
{
    private readonly JsonDataContext context;

    public JsonCategoryProvider(JsonDataContext context)
    {
        this.context = context;
    }

    public Task<ICollection<CategoryDto>> GetCategoryCardsDTOAsync(string teacherName)
    {
        ICollection<CategoryDto> categoryDtos = context.Categories.Where(c => c.OwnerId.Equals(teacherName))
            .Select(c => new CategoryDto(c.Id, c.Title, c.BackgroundColor)).ToList();
        return Task.FromResult(categoryDtos);
    }

    public Task<ICollection<CategoryWithGuidesAndResourcesDto>> GetCategoriesWithGuideHeadersAsync(string teacher)
    {
        ICollection<CategoryWithGuidesAndResourcesDto> categoriesWithGuides = new List<CategoryWithGuidesAndResourcesDto>();

        // get all uncategorized guides for teacher
        CategoryWithGuidesAndResourcesDto unCatCwg = CreateUnCategorized(teacher);

        categoriesWithGuides.Add(unCatCwg);

        // get all categories for teacher
        ICollection<CategoryDto> categoryDtos = context.Categories.Where(c => c.OwnerId.Equals(teacher))
            .Select(c => new CategoryDto(c.Id, c.Title, c.BackgroundColor)).ToList();

        // get all and resources guides per category
        foreach (CategoryDto cat in categoryDtos)
        {
            List<GuideHeaderDto> guideHeaderDtos = context.Guides
                .Where(g => g.CategoryId.Equals(cat.Id))
                .Select(g => new GuideHeaderDto(g.Id, g.Title))
                .ToList();

            List<ExternalResourceDisplayDto> externalResourceDisplayDtos = context.ExternalResources
                .Where(er => er.CategoryId.Equals(cat.Id))
                .Select(r => new ExternalResourceDisplayDto
                {
                    Id = r.Id,
                    Title = r.Title,
                    Url = r.Url,
                    Description = r.Description
                })
                .ToList();

            CategoryWithGuidesAndResourcesDto cwg = new();
            cwg.Category = cat;
            cwg.Guides = guideHeaderDtos;
            cwg.ExternalResources = externalResourceDisplayDtos;
            categoriesWithGuides.Add(cwg);
        }

        return Task.FromResult(categoriesWithGuides);
    }

    private CategoryWithGuidesAndResourcesDto CreateUnCategorized(string teacher)
    {
        CategoryWithGuidesAndResourcesDto unCatCwg = new();
        ICollection<GuideHeaderDto> guidesForUncategorized = context.Guides
            .Where(g => g.CategoryId is null && g.OwnerId.Equals(teacher))
            .Select(g => new GuideHeaderDto(g.Id, g.Title)).ToList();
        ICollection<ExternalResourceDisplayDto> resourcesForUncategorized = context.ExternalResources
            .Where(g => g.CategoryId is null && g.OwnerId.Equals(teacher))
            .Select(er => new ExternalResourceDisplayDto
            {
                Id = er.Id,
                Title = er.Title,
                Url = er.Url,
                Description = er.Description
            }).ToList();
        unCatCwg.Guides = guidesForUncategorized;
        unCatCwg.ExternalResources = resourcesForUncategorized;
        return unCatCwg;
    }
}