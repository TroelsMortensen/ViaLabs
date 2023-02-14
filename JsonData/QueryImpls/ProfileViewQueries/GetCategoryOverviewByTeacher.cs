using JsonData.Context;
using ViewData;
using ViewData.ProfileInfo.DTOs;
using ViewData.ProfileInfo.Queries;

namespace JsonData.QueryImpls.ProfileViewQueries;

internal class GetCategoryOverviewByTeacher : IQueryHandler<GetProfileInfo, ICollection<CategoryWithGuidesAndResourcesDto>>
{
    private readonly JsonDataContext context;

    internal GetCategoryOverviewByTeacher(JsonDataContext context)
    {
        this.context = context;
    }

    // public Task<ICollection<CategoryDto>> GetCategoryCardsDTOAsync(string teacherName)
    // {
    //     context.Teachers.First(t => t.Name.Equals(teacherName)).Categories.Select();
    //     ICollection<CategoryDto> categoryDtos = context.Categories.Where(c => c.OwnerId.Equals(teacherName))
    //         .Select(c => new CategoryDto(c.Id, c.Title, c.BackgroundColor)).ToList();
    //     return Task.FromResult(categoryDtos);
    // }

    public Task<ICollection<CategoryWithGuidesAndResourcesDto>> Query(GetProfileInfo query)
    {
        string teacher = query.TeacherName;
        // get all categories for teacher
        ICollection<CategoryWithGuidesAndResourcesDto> categoriesWithGuidesAndExRes = context
            .Categories
            .Where(category => category.Owner.Equals(teacher))
            .Select(c =>
                new CategoryWithGuidesAndResourcesDto(
                    new CategoryDto(c.Id, c.Title, c.BackgroundColor),
                    context.Guides.Where(guide => guide.Category.Equals(c.Id)).Select(g => new GuideHeaderDto(g.Id, g.Title)).ToList(),
                    context.ExternalResources.Where(ext => ext.Category.Equals(c.Id)).Select(er => new ExternalResourceDisplayDto(er.Id, er.Title, er.Url, er.Description)).ToList()
                )
            )
            .ToList();

        return Task.FromResult(categoriesWithGuidesAndExRes);
    }

    // private CategoryWithGuidesAndResourcesDto CreateUnCategorized(string teacher)
    // {
    //     CategoryWithGuidesAndResourcesDto unCatCwg = new();
    //     ICollection<GuideHeaderDto> guidesForUncategorized = context.Guides
    //         .Where(g => g.CategoryId is null && g.OwnerId.Equals(teacher))
    //         .Select(g => new GuideHeaderDto(g.Id, g.Title)).ToList();
    //     ICollection<ExternalResourceDisplayDto> resourcesForUncategorized = context.ExternalResources
    //         .Where(g => g.CategoryId is null && g.OwnerId.Equals(teacher))
    //         .Select(er => new ExternalResourceDisplayDto
    //         {
    //             Id = er.Id,
    //             Title = er.Title,
    //             Url = er.Url,
    //             Description = er.Description
    //         }).ToList();
    //     unCatCwg.Guides = guidesForUncategorized;
    //     unCatCwg.ExternalResources = resourcesForUncategorized;
    //     return unCatCwg;
    // }
}