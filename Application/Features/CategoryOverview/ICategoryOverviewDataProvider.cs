using Application.Features.ProfileDataLogic.DTOs.CategoryDTOs;

namespace Application.Features.CategoryOverview;

public interface ICategoryOverviewDataProvider
{
    // Task<ICollection<CategoryDto>> GetCategoryCardsDTOAsync(string teacherName);

    Task<ICollection<CategoryWithGuidesAndResourcesDto>> GetCategoriesWithGuideHeadersByTeacherAsync(string teacher);
}