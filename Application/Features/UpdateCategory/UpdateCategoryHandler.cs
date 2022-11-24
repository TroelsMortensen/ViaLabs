using Application.RepositoryContracts;
using Domain.Models;
using SharedKernel.Results;

namespace Application.Features.UpdateCategory;

public class UpdateCategoryHandler : IUpdateCategoryHandler
{
    private readonly IRepoManager repoManager;

    public UpdateCategoryHandler(IRepoManager repoManager)
    {
        this.repoManager = repoManager;
    }

    public async Task<Result> UpdateAsync(UpdateCategoryRequest request)
    {
        Category catBeingUpdated = await repoManager.CategoryRepo.GetCategoryById(request.Id);
        Result result = catBeingUpdated.Update(request.Title, request.BackgroundColor);
        if (result.HasErrors)
        {
            return result;
        }

        await repoManager.CategoryRepo.UpdateAsync(catBeingUpdated);
        
        return result;
    }
}