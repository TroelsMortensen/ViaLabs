using SharedKernel.OperationResult;

namespace Application.Features.CategoryDelete;

public interface ICategoryDeleteHandler
{
    Task<Result> DeleteAsync(Guid categoryId);

}