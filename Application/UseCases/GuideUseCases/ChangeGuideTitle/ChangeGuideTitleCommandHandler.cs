using Application.HandlerContracts;
using Application.RepositoryContracts;
using Domain.Aggregates;
using Domain.OperationResult;

namespace Application.UseCases.GuideUseCases.ChangeGuideTitle;

public class ChangeGuideTitleCommandHandler : ICommandHandler<ChangeGuideTitleCommand>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IGuideRepo guideRepo;

    public ChangeGuideTitleCommandHandler(IUnitOfWork unitOfWork, IGuideRepo guideRepo)
    {
        this.unitOfWork = unitOfWork;
        this.guideRepo = guideRepo;
    }

    public async Task<Result> Handle(ChangeGuideTitleCommand command)
    {
        Guide guide = await guideRepo.GetAsync(command.GuideId);
        Result result = guide.ChangeTitle(command.NewTitle);
        if (result.IsFailure)
        {
            return result;
        }

        await unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}