using Application.DTOs.CategoryDTOs;

namespace Application.Providers;

public interface ICategoryProvider
{
    Task<ICollection<CategoryDto>> GetCategoryCardsDTOAsync(string teacherName);

}