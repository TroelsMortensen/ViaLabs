using Application.Features.SharedDtos;
using SharedKernel.OperationResult;

namespace Application.Features.CategoryCreate;

public interface ICategoryCreateHandler
{
    public Task<Result<CategoryDto>> CreateAsync(CategoryCreateRequest request);

}