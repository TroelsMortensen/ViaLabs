using Application.HandlerContracts;
using Application.RepositoryContracts;
using Domain.Aggregates;
using Domain.OperationResult;
using Domain.Values;

namespace Application.UseCases.GuideUseCases.CreateGuide;

public class GuideCreateHandler : ICommandHandler<CreateGuideCommand>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IGuideRepo guideRepo;

    public GuideCreateHandler(IUnitOfWork unitOfWork, IGuideRepo guideRepo)
    {
        this.unitOfWork = unitOfWork;
        this.guideRepo = guideRepo;
    }

    public async Task<Result> Handle(CreateGuideCommand command)
    {
        Result<Guide> result = Guide.Create(command.GuideId, command.Title,  CategoryId.FromGuid(command.CategoryId), command.TeacherName);
        if (result.HasErrors)
        {
            return Result.Failure(result.Errors);
        }

        Guide newGuide = result.Value;
        await guideRepo.CreateAsync(newGuide);
        await unitOfWork.SaveChangesAsync();
        
        return Result.Success();
    }
}