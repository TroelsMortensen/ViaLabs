using Application.Features.ProfileDataLogic.DTOs.CategoryDTOs;

namespace Application.Features.ProfileDataLogic.ProviderContracts;

public interface ICategoryProvider
{
    Task<ICollection<CategoryDto>> GetCategoryCardsDTOAsync(string teacherName);

    Task<ICollection<CategoryWithGuidesAndResourcesDto>> GetCategoriesWithGuideHeadersAsync(string teacher);
}