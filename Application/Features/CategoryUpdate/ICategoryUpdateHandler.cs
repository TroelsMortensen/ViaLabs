using SharedKernel.OperationResult;

namespace Application.Features.CategoryUpdate;

public interface ICategoryUpdateHandler
{
    Task<Result> UpdateAsync(UpdateCategoryRequest request);
}