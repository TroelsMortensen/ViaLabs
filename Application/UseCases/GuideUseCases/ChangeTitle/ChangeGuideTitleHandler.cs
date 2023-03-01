using Application.HandlerContracts;
using Application.RepositoryContracts;
using Domain.Entities;
using Domain.OperationResult;

namespace Application.UseCases.GuideUseCases.ChangeTitle;

public class ChangeGuideTitleHandler : ICommandHandler<ChangeGuideTitleCommand>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IGuideRepo guideRepo;

    public ChangeGuideTitleHandler(IUnitOfWork unitOfWork, IGuideRepo guideRepo)
    {
        this.unitOfWork = unitOfWork;
        this.guideRepo = guideRepo;
    }

    public async Task<Result> Handle(ChangeGuideTitleCommand command)
    {
        Guide guide = await guideRepo.GetAsync(command.GuideId);
        Result result = guide.ChangeTitle(command.NewTitle);
        if (result.HasErrors)
        {
            return result;
        }

        await unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}