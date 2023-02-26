using JsonData.Context;
using ViewData;
using ViewData.ProfileInfo.DTOs;
using ViewData.ProfileInfo.Queries;

namespace JsonData.QueryImpls.ProfileViewQueries;

public class ProfileInfoOverviewQueryHandler : IQueryHandler<ProfileInfoOverviewQuery, ICollection<CategoryWithGuidesAndResourcesVM>>
{
    private readonly JsonDataContext context;

    public ProfileInfoOverviewQueryHandler(JsonDataContext context)
    {
        this.context = context;
    }

    

    public Task<ICollection<CategoryWithGuidesAndResourcesVM>> Query(ProfileInfoOverviewQuery query)
    {
        string teacher = query.TeacherName;
        // get all categories for teacher
        ICollection<CategoryWithGuidesAndResourcesVM> categoriesWithGuidesAndExRes = context
            .Categories
            .Where(category => category.Owner.Equals(teacher))
            .Select(c =>
                new CategoryWithGuidesAndResourcesVM(
                    new CategoryVM(c.Id, c.Title, c.BackgroundColor),
                    context.Guides.Where(guide => guide.CategoryId.Equals(c.Id)).Select(g => new GuideHeaderVM(g.Id, g.Title)).ToList(),
                    context.ExternalResources.Where(ext => ext.CategoryId.Equals(c.Id)).Select(er => new ExternalResourceDisplayVM(er.Id, er.Title, er.Url, er.Description)).ToList()
                )
            )
            .ToList();

        return Task.FromResult(categoriesWithGuidesAndExRes);
    }

    // public Task<ICollection<CategoryDto>> GetCategoryCardsDTOAsync(string teacherName)
    // {
    //     context.Teachers.First(t => t.Name.Equals(teacherName)).Categories.Select();
    //     ICollection<CategoryDto> categoryDtos = context.Categories.Where(c => c.OwnerId.Equals(teacherName))
    //         .Select(c => new CategoryDto(c.Id, c.Title, c.BackgroundColor)).ToList();
    //     return Task.FromResult(categoryDtos);
    // }
    
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