using Application.DTOs.GuideDTOs;
using Application.RepositoryContracts;
using Application.ServiceContracts;
using Entities;

namespace Application.ServiceImpls;

public class GuideService : IGuideService
{
    private readonly IRepoUOW repoUow;

    public GuideService(IRepoUOW repoUow)
    {
        this.repoUow = repoUow;
    }

    public async Task<GuideHeaderDto> CreateGuideAsync(GuideCreationDto guide)
    {
        ValidateGuide(guide);
        Guide guideToCreate = new Guide
        {
            Id = Guid.NewGuid(),
            Title = guide.Title,
            CategoryId = guide.CategoryId,
            OwnerId = guide.OwnerId
        };
        
        await repoUow.GuideRepo.CreateAsync(guideToCreate);
        await repoUow.SaveChangesAsync();
        
        return new GuideHeaderDto
        {
            Id = guideToCreate.Id,
            Title = guideToCreate.Title
        };
    }


    private void ValidateGuide(GuideCreationDto guide)
    {
        if (guide.Title.Length < 3) throw new Exception("Guide title must be more than 3 characters");
        if (guide.Title.Length > 75) throw new Exception("Guide title must be less than 75 characters");
        if (string.IsNullOrEmpty(guide.OwnerId)) throw new Exception("Something went terribly wrong, and there was no recovery");
    }
}