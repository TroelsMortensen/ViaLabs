using Application.RepositoryContracts;
using Domain.Entities;
using SharedKernel.Results;

namespace Application.Features.CategoryDelete;

public class CategoryDeleteHandler : ICategoryDeleteHandler
{
    private readonly IRepoManager repoManager;

    public CategoryDeleteHandler(IRepoManager repoManager)
    {
        this.repoManager = repoManager;
    }

    public async Task<Result> DeleteAsync(Guid categoryId)
    {
        ICategoryRepo catRepo = repoManager.CategoryRepo;
        Category categoryForDeletion = await catRepo.GetCategoryByIdAsync(categoryId);
        Result result = CheckIfCategoryCanBeDeleted(categoryForDeletion);
        if (result.HasErrors) return result;
        
        await catRepo.DeleteAsync(categoryId);

        return result;
    }

    private static Result CheckIfCategoryCanBeDeleted(Category categoryForDeletion)
    {
        Result result = new();
        if (categoryForDeletion.Guides.Any())
        {
            result.AddError("Category.Guides", "Cannot delete a category, which contains guides.");
        }

        if (categoryForDeletion.ExternalResources.Any())
        {
            result.AddError("Category.ExternalResources", "Cannot delete a category, which contains external resources.");
        }

        return result;
    }
}