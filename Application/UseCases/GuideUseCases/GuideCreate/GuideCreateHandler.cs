﻿using Application.HandlerContracts;
using Application.RepositoryContracts;
using Domain.Entities;
using Domain.OperationResult;

namespace Application.UseCases.GuideUseCases.GuideCreate;

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
        Result<Guide> result = Guide.Create(command.GuideId, command.Title, command.CategoryId, command.TeacherId);
        if (result.HasErrors)
        {
            return Result.Failure(result.Errors);
        }
        
        return Result.Success();
    }
}