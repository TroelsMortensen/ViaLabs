using Application.HandlerContracts;
using Application.RepositoryContracts;
using Domain.Entities;
using Domain.OperationResult;

namespace Application.UseCases.GuideUseCases.ChangeDescription;

public class ChangeGuideDescriptionCommandHandler : ICommandHandler<ChangeGuideDescriptionCommand>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IGuideRepo guideRepo;

    public ChangeGuideDescriptionCommandHandler(IGuideRepo guideRepo, IUnitOfWork unitOfWork)
    {
        this.guideRepo = guideRepo;
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(ChangeGuideDescriptionCommand command)
    {
        Guide guide = await guideRepo.GetAsync(command.GuideId);
        
        Result result = guide.ChangeDescription(command.Description);
        
        if (result.HasErrors) return result;

        await unitOfWork.SaveChangesAsync();
        
        return Result.Success();
    }
}