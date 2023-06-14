using Application.HandlerContracts;
using Application.RepositoryContracts;
using Domain.Aggregates;
using Domain.OperationResult;

namespace Application.UseCases.GuideUseCases.ChangeSlidesNumberVisibility;

public class HideGuideStepNumbersCommandHandler : ICommandHandler<HideStepNumbersCommand>
{

    private readonly IUnitOfWork unitOfWork;
    private readonly IGuideRepo guideRepo;

    public HideGuideStepNumbersCommandHandler(IUnitOfWork unitOfWork, IGuideRepo guideRepo)
    {
        this.unitOfWork = unitOfWork;
        this.guideRepo = guideRepo;
    }

    public async Task<Result> Handle(HideStepNumbersCommand command)
    {
        Guide guide = await guideRepo.GetAsync(command.GuideId);
        guide.HideStepNums();
        await unitOfWork.SaveChangesAsync();
        return Result.Success();
    }

   
}