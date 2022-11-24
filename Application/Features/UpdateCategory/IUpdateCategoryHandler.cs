using SharedKernel.Results;

namespace Application.Features.UpdateCategory;

public interface IUpdateCategoryHandler
{
    Task<Result> UpdateAsync(UpdateCategoryRequest request);
}