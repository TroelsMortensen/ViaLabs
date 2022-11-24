using Application.RepositoryContracts;
using SharedKernel.Results;

namespace Application.Features.CategoryDelete;

public class CategoryDeleteHandler : ICategoryDeleteHandler
{
    private readonly IRepoManager repoManager;

    public CategoryDeleteHandler(IRepoManager repoManager)
    {
        this.repoManager = repoManager;
    }

    public Task<Result> DeleteAsync(Guid categoryId)
    {
        throw new NotImplementedException();
    }
}