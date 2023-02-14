using Application.RepositoryContracts;
using Domain.Entities;
using SharedKernel.OperationResult;

namespace Application.Features.CategoryUpdate;

public class CategoryUpdateHandler : ICategoryUpdateHandler
{
    private readonly IUnitOfWork unitOfWork;
    private readonly ICategoryRepo categoryRepo;

    public CategoryUpdateHandler(IUnitOfWork unitOfWork, ICategoryRepo categoryRepo)
    {
        this.unitOfWork = unitOfWork;
        this.categoryRepo = categoryRepo;
    }

    public async Task<Result> UpdateAsync(UpdateCategoryRequest request)
    {
        Category catBeingUpdated = await categoryRepo.GetAsync(request.Id);
        Result result = catBeingUpdated.Update(request.Title, request.BackgroundColor);
        if (result.HasErrors)
        {
            return result;
        }

        await unitOfWork.SaveChanges();
        
        return result;
    }
}