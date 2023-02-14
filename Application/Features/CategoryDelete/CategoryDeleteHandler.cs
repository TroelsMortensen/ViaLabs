using Application.RepositoryContracts;
using Domain.Entities;
using SharedKernel.OperationResult;

namespace Application.Features.CategoryDelete;

public class CategoryDeleteHandler : ICategoryDeleteHandler
{
    private readonly IUnitOfWork unitOfWork;
    private readonly ICategoryRepo categoryRepo;
    private readonly IGuideRepo guideRepo;
    private readonly IExternalResourceRepo externalResourceRepo;

    public CategoryDeleteHandler(IUnitOfWork unitOfWork, ICategoryRepo categoryRepo, IGuideRepo guideRepo,
        IExternalResourceRepo externalResourceRepo)
    {
        this.unitOfWork = unitOfWork;
        this.categoryRepo = categoryRepo;
        this.guideRepo = guideRepo;
        this.externalResourceRepo = externalResourceRepo;
    }

    public async Task<Result> DeleteAsync(Guid categoryId)
    {
        Category categoryForDeletion = await categoryRepo.GetAsync(categoryId);
        Result result = await CheckIfCategoryCanBeDeleted(categoryForDeletion);

        if (result.HasErrors) return result;

        await categoryRepo.DeleteAsync(categoryId);
        await unitOfWork.SaveChanges();

        return result;
    }

    private async Task<Result> CheckIfCategoryCanBeDeleted(Category categoryForDeletion)
    {
        Result result = new();
        ICollection<Guide> guidesInCategory = await guideRepo.GetByCategoryAsync(categoryForDeletion.Id);
        if (guidesInCategory.Any())
        {
            result.AddError("Category.Guides", "Cannot delete a category, which contains guides.");
        }

        ICollection<ExternalResource> externalResources = await externalResourceRepo.GetByCategoryAsync(categoryForDeletion.Id);
        if (externalResources.Any())
        {
            result.AddError("Category.ExternalResources", "Cannot delete a category, which contains external resources.");
        }

        return result;
    }
}