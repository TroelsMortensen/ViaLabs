using Application.HandlerContracts;
using Application.RepositoryContracts;
using Domain.Entities;
using Domain.OperationResult;

namespace Application.CommandUseCases.CategoryHandlers.CategoryUpdate;

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