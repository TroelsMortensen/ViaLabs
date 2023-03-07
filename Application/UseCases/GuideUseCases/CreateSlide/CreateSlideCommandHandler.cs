using Application.HandlerContracts;
using Application.RepositoryContracts;
using Domain.Entities;
using Domain.OperationResult;

namespace Application.UseCases.GuideUseCases.CreateSlide;

public class CreateSlideCommandHandler : ICommandHandler<CreateSlideCommand>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IGuideRepo guideRepo;
private readonly ISlideContentRepo slideContentRepo;
    public CreateSlideCommandHandler(IUnitOfWork unitOfWork, IGuideRepo guideRepo, ISlideContentRepo slideContentRepo)
    {
        this.unitOfWork = unitOfWork;
        this.guideRepo = guideRepo;
        this.slideContentRepo = slideContentRepo;
    }

    public async Task<Result> Handle(CreateSlideCommand command)
    {
        SlideContent slideContent = SlideContent.Create(command.SlideContentId);
                await slideContentRepo.CreateAsync(slideContent);
        
        
        
        Guide guide = await guideRepo.GetAsync(command.GuideId);
        guide.AddSlide(command.SlideId, command.StepIndex, command.SlideContentId);

        await unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}