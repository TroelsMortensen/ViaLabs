using Application.HandlerContracts;
using Application.RepositoryContracts;
using Domain.Aggregates;
using Domain.OperationResult;
using Domain.Utils;

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
        Category catBeingUpdated = await categoryRepo.GetAsync(request.Id);
        // Category catBeingUpdated = existingCategoryResult.Value;
        Result result = catBeingUpdated.Update(request.Title, request.BackgroundColor);
        if (result.IsFailure)
        {
            return result;
        }
    
        await unitOfWork.SaveChangesAsync();
        
        return result;
    }

    // public async Task<Result> Handle(UpdateCategoryCommand request)
    // {
    //     Result<Category> result = await categoryRepo.GetAsync(request.Id)
    //             .IfSuccess(
    //                 (r) =>
    //                     new Result<Category>(r.Value.Update(request.Title, request.BackgroundColor))
    //             )
    //             .IfSuccess(
    //                 (r) =>
    //                 {
    //                     unitOfWork.SaveChangesAsync();
    //                     return r;
    //                 }
    //             )
    //         ;
    //     
    //     return new Result(result.Errors);
    // }
}