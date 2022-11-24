using Application.Features.OldStuffToBeMovedAround.LogicContracts;
using Application.Features.ProfileDataLogic.LogicContracts;
using Application.Features.SharedDtos;
using Application.RepositoryContracts;
using Domain.Exceptions;
using Domain.Models;
using SharedKernel.Results;

namespace Application.Features.ProfileDataLogic.LogicImpls;

public class CategoryLogic : ICategoryLogic
{
    private readonly IRepoManager repoManager;

    public CategoryLogic(IRepoManager repoManager)
    {
        this.repoManager = repoManager;
    }



    public async Task<Result> UpdateAsync(CategoryDto toUpdate)
    {
        Category catBeingUpdated = await repoManager.CategoryRepo.GetCategoryById(toUpdate.Id);
        Result result = catBeingUpdated.Update(toUpdate.Title, toUpdate.BackgroundColor);
        if (result.HasErrors)
        {
            return result;
        }
        // ValidateNewCategoryData(catBeingUpdated);

        await repoManager.CategoryRepo.UpdateAsync(catBeingUpdated);
        
        return result;
    }

    public async Task DeleteAsync(Guid categoryId)
    {
        // cannot delete something which has resources. Do not do cascade.

        throw new NotImplementedException("Mangler her");

        await repoManager.CategoryRepo.DeleteAsync(categoryId);
    }
}