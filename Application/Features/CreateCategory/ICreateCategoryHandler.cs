using Application.Features.SharedDtos;
using SharedKernel.Results;

namespace Application.Features.CreateCategory;

public interface ICreateCategoryHandler
{
    public Task<Result<CategoryDto>> CreateAsync(CreateCategoryRequest request);

}