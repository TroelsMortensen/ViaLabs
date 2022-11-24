using SharedKernel.Results;

namespace Application.Features.CategoryUpdate;

public interface ICategoryUpdateHandler
{
    Task<Result> UpdateAsync(UpdateCategoryRequest request);
}