using Application.Features.ProfileDataLogic.DTOs.CategoryDTOs;

namespace Application.Features.ProfileDataLogic.LogicContracts;

public interface ICategoryLogic
{
    public Task<CategoryDto> CreateAsync(CategoryCreationDto dto);
    Task UpdateAsync(CategoryDto toUpdate);
    Task DeleteAsync(Guid categoryId);
}