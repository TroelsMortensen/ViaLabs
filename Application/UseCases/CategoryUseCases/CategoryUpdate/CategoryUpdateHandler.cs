using Application.HandlerContracts;
using Application.RepositoryContracts;
using Domain.OperationResult;

namespace Application.UseCases.CategoryUseCases.CategoryUpdate;

public class CategoryUpdateHandler : ICommandHandler<UpdateCategoryCommand>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly ICategoryRepo categoryRepo;

    public CategoryUpdateHandler(IUnitOfWork unitOfWork, ICategoryRepo categoryRepo)
    {
        this.unitOfWork = unitOfWork;
        this.categoryRepo = categoryRepo;
    }

    public async Task<Result> Handle(UpdateCategoryCommand request)
    {
        Domain.Entities.Category catBeingUpdated = await categoryRepo.GetAsync(request.Id);
        Result result = catBeingUpdated.Update(request.Title, request.BackgroundColor);
        if (result.HasErrors)
        {
            return result;
        }

        await unitOfWork.SaveChangesAsync();
        
        return result;
    }
}