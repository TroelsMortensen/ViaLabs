using Application.Features.ProfileDataLogic.DTOs.CategoryDTOs;

namespace Application.Features.ProfileDataLogic.LogicContracts;

public interface ICategoryLogic
{
    public Task<CategoryDto> CreateAsync(CategoryCreationRequest request);
    Task UpdateAsync(CategoryDto toUpdate);
    Task DeleteAsync(Guid categoryId);
}