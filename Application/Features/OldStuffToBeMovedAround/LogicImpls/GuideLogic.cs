using Application.Features.ProfileDataLogic.DTOs.GuideDTOs;
using Application.Features.ProfileDataLogic.LogicContracts;
using Application.Features.SharedDtos;
using Application.RepositoryContracts;
using Domain.Entities;

namespace Application.Features.ProfileDataLogic.LogicImpls;

public class GuideLogic : IGuideLogic
{
    private readonly IRepoManager repoManager;

    public GuideLogic(IRepoManager repoManager)
    {
        this.repoManager = repoManager;
    }

    public async Task<GuideHeaderDto> CreateGuideAsync(GuideCreationDto guide)
    {
        throw new NotImplementedException();

        // ValidateGuide(guide);
        // Guide guideToCreate = new ()
        // {
        //     Id = Guid.NewGuid(),
        //     Title = guide.Title,
        //     CategoryId = guide.CategoryId,
        //     OwnerId = guide.OwnerId
        // };
        // try
        // {
        //     await Create(guideToCreate);
        // }
        // catch (Exception e)
        // {
        //     await repoManager.RollbackAsync();
        //     throw;
        // }
        //
        // return new GuideHeaderDto(guideToCreate.Id, guideToCreate.Title);
    }

    private async Task Create(Guide guideToCreate)
    {
        throw new NotImplementedException();
        // await repoManager.BeginAsync();
        // await repoManager.GuideRepo.CreateAsync(guideToCreate);
        // await repoManager.SaveChangesAsync();
    }


    private void ValidateGuide(GuideCreationDto guide)
    {
        if (guide.Title.Length < 3) throw new Exception("Guide title must be more than 3 characters");
        if (guide.Title.Length > 75) throw new Exception("Guide title must be less than 75 characters");
        if (string.IsNullOrEmpty(guide.OwnerId)) throw new Exception("Something went terribly wrong, and there was no recovery");
    }
}