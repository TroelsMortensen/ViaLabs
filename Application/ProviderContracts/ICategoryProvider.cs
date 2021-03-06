using Application.DTOs.CategoryDTOs;
using Application.DTOs.GuideDTOs;

namespace Application.ProviderContracts;

public interface ICategoryProvider
{
    Task<ICollection<CategoryDto>> GetCategoryCardsDTOAsync(string teacherName);

    Task<ICollection<CategoryWithGuidesAndResourcesDto>> GetCategoriesWithGuideHeadersAsync(string teacher);
}