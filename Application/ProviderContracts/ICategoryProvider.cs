using Application.DTOs.CategoryDTOs;

namespace Application.ProviderContracts;

public interface ICategoryProvider
{
    Task<ICollection<CategoryDto>> GetCategoryCardsDTOAsync(string teacherName);

}