using Application.HandlerContracts;
using Application.RepositoryContracts;
using Domain.Entities;
using Domain.OperationResult;

namespace Application.UseCases.GuideUseCases.CreateSlide;

public class CreateSlideCommandHandler : ICommandHandler<CreateSlideCommand>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IGuideRepo guideRepo;

    public CreateSlideCommandHandler(IUnitOfWork unitOfWork, IGuideRepo guideRepo)
    {
        this.unitOfWork = unitOfWork;
        this.guideRepo = guideRepo;
    }

    public async Task<Result> Handle(CreateSlideCommand command)
    {
        Guide guide = await guideRepo.GetAsync(command.GuideId);
        guide.AddSlide(command.SlideId, command.StepIndex, command.SlideContentId);

        await unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}