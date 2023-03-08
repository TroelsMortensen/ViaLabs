using Application.HandlerContracts;
using Application.RepositoryContracts;
using Domain.Entities;
using Domain.OperationResult;

namespace Application.UseCases.GuideUseCases.ChangeSlidesNumberVisibility;

public class ShowGuideStepNumbersCommandHandler :  ICommandHandler<ShowStepNumbersCommand>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IGuideRepo guideRepo;

    public ShowGuideStepNumbersCommandHandler(IGuideRepo guideRepo, IUnitOfWork unitOfWork)
    {
        this.guideRepo = guideRepo;
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(ShowStepNumbersCommand command)
    {
        Guide guide = await guideRepo.GetAsync(command.GuideId);
        guide.DisplayStepNums();
        await unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}