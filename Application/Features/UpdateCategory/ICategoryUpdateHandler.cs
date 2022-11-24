using SharedKernel.Results;

namespace Application.Features.UpdateCategory;

public interface ICategoryUpdateHandler
{
    Task<Result> UpdateAsync(CategoryUpdateRequest request);
}