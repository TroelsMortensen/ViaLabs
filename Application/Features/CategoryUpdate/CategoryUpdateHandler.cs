using Application.RepositoryContracts;
using Domain.Models;
using SharedKernel.Results;

namespace Application.Features.CategoryUpdate;

public class CategoryUpdateHandler : ICategoryUpdateHandler
{
    private readonly IRepoManager repoManager;

    public CategoryUpdateHandler(IRepoManager repoManager)
    {
        this.repoManager = repoManager;
    }

    public async Task<Result> UpdateAsync(UpdateCategoryRequest request)
    {
        Category catBeingUpdated = await repoManager.CategoryRepo.GetCategoryByIdAsync(request.Id);
        Result result = catBeingUpdated.Update(request.Title, request.BackgroundColor);
        if (result.HasErrors)
        {
            return result;
        }

        await repoManager.CategoryRepo.UpdateAsync(catBeingUpdated);
        
        return result;
    }
}