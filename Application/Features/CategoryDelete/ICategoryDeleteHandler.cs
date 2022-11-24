using SharedKernel.Results;

namespace Application.Features.CategoryDelete;

public interface ICategoryDeleteHandler
{
    Task<Result> DeleteAsync(Guid categoryId);

}