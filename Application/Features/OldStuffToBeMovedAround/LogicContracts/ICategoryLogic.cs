using Application.Features.CreateCategory;
using Application.Features.SharedDtos;
using SharedKernel.Results;

namespace Application.Features.OldStuffToBeMovedAround.LogicContracts;

public interface ICategoryLogic
{
    // public Task<Result<CategoryDto>> CreateAsync(CategoryCreationRequest request);
    Task<Result> UpdateAsync(CategoryDto toUpdate);
    Task DeleteAsync(Guid categoryId);
}