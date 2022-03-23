using Application.DTOs.CategoryDTOs;

namespace Application.Providers;

public interface ICategoryProvider
{
    Task<List<CategoryDto>> GetCategoryCardsDTOAsync(string teacherName);

}