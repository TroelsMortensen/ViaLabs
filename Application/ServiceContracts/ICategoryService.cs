using Application.DTOs.CategoryDTOs;

namespace Application.ServiceContracts;

public interface ICategoryService
{
    public Task<CategoryDto> CreateAsync(CategoryCreationDto category);
    Task UpdateAsync(CategoryDto toUpdate);
    Task DeleteAsync(Guid categoryId);
}