using Application.Features.ProfileDataLogic.DTOs.CategoryDTOs;

namespace Application.Features.ProfileDataLogic.LogicContracts;

public interface ICategoryLogic
{
    public Task<CategoryDto> CreateAsync(CategoryCreationDto category);
    Task UpdateAsync(CategoryDto toUpdate);
    Task DeleteAsync(Guid categoryId);
}