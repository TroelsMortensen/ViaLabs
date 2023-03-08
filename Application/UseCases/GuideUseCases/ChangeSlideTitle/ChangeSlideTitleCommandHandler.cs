using Application.HandlerContracts;
using Application.RepositoryContracts;
using Domain.Entities;
using Domain.OperationResult;

namespace Application.UseCases.GuideUseCases.ChangeSlideTitle;

public class ChangeSlideTitleCommandHandler : ICommandHandler<ChangeSlideTitleCommand>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IGuideRepo guideRepo;

    public ChangeSlideTitleCommandHandler(IUnitOfWork unitOfWork, IGuideRepo guideRepo)
    {
        this.unitOfWork = unitOfWork;
        this.guideRepo = guideRepo;
    }

    public async Task<Result> Handle(ChangeSlideTitleCommand command)
    {
        Guide guide = await guideRepo.GetAsync(command.GuideId);
        Result result = guide.ChangeSlideTitle(command.StepId, command.Title);
    
        return Result.Success();
    }
}