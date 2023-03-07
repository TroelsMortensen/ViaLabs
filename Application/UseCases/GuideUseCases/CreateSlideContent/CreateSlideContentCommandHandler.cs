using Application.HandlerContracts;
using Application.RepositoryContracts;
using Domain.Entities;
using Domain.OperationResult;

namespace Application.UseCases.GuideUseCases.CreateSlideContent;

public class CreateSlideContentCommandHandler : ICommandHandler<CreateSlideContentCommand>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly ISlideContentRepo slideContentRepo;

    public CreateSlideContentCommandHandler(IUnitOfWork unitOfWork, ISlideContentRepo slideContentRepo)
    {
        this.unitOfWork = unitOfWork;
        this.slideContentRepo = slideContentRepo;
    }

    public async Task<Result> Handle(CreateSlideContentCommand command)
    {
        SlideContent slideContent = SlideContent.Create(command.SlideContentId);
        await slideContentRepo.CreateAsync(slideContent);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}