using Application.EntryContracts;
using Application.Repositories;
using Entities;

namespace Application.HomeImpls;

public class GuideHome : IGuideHome
{
    private readonly IGuideRepo guideRepo;

    public GuideHome(IGuideRepo guideRepo)
    {
        this.guideRepo = guideRepo;
    }

    public async Task<Guide> CreateGuideAsync(Guide guide)
    {
        ValidateGuide(guide);
        guide.Id = Guid.NewGuid();
        await guideRepo.CreateAsync(guide);
        return guide;
    }

    public Task<ICollection<Guide>> GetGuidesByCategoryIdAsync(Guid categoryId)
    {
        return guideRepo.GetGuidesByCategoryIdAsync(categoryId);
    }

    private void ValidateGuide(Guide guide)
    {
        if (guide.Title.Length < 3) throw new Exception("Guide title must be more than 3 characters");
        if (guide.Title.Length > 75) throw new Exception("Guide title must be less than 75 characters");
        if (string.IsNullOrEmpty(guide.OwnerId)) throw new Exception("Something went terribly wrong, and there was no recovery");
    }
}