using Application.HandlerContracts;
using Application.RepositoryContracts;
using Domain.Aggregates;
using Domain.OperationResult;

namespace Application.UseCases.GuideUseCases.MoveGuideToCategory;

public class ChangeGuideCategoryCommandHandler : ICommandHandler<ChangeGuideCategoryCommand>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IGuideRepo guideRepo;
    private readonly ICategoryRepo categoryRepo;

    public ChangeGuideCategoryCommandHandler(IUnitOfWork unitOfWork, IGuideRepo guideRepo, ICategoryRepo categoryRepo)
    {
        this.unitOfWork = unitOfWork;
        this.guideRepo = guideRepo;
        this.categoryRepo = categoryRepo;
    }

    public async Task<Result> Handle(ChangeGuideCategoryCommand command)
    {
        Guide guide = await guideRepo.GetAsync(command.GuideId);
        Category category = await categoryRepo.GetAsync(command.CategoryId);

        guide.ChangeCategoryTo(category);
        
        await unitOfWork.SaveChangesAsync();
        
        return Result.Success();
    }
}