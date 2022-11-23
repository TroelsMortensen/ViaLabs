using Application.Features.ProfileDataLogic.DTOs.CategoryDTOs;
using SharedKernel.Results;

namespace Application.Features.CreateCategory;

public interface ICreateCategoryHandler
{
    public Task<Result<CategoryDto>> CreateAsync(CategoryCreationRequest request);

}