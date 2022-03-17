using Application.EntryContracts;
using Application.Repositories;
using Entities;

namespace Application.HomeImpls;

public class GuideService : IGuideService
{
    private readonly IRepoManager repoManager;

    public GuideService(IRepoManager repoManager)
    {
        this.repoManager = repoManager;
    }

    public async Task<Guide> CreateGuideAsync(Guide guide)
    {
        ValidateGuide(guide);
        guide.Id = Guid.NewGuid();
        await repoManager.GuideRepo.CreateAsync(guide);
        await repoManager.SaveChangesAsync();
        return guide;
    }

    public Task<ICollection<Guide>> GetGuidesByCategoryIdAsync(Guid categoryId)
    {
        return repoManager.GuideRepo.GetGuidesByCategoryIdAsync(categoryId);
    }

    public Task<ICollection<Guide>> GetUnCategorizedByTeacherAsync(string teacher)
    {
        return repoManager.GuideRepo.GetUnCategorizedGuidesByUserId(teacher);
    }

    private void ValidateGuide(Guide guide)
    {
        if (guide.Title.Length < 3) throw new Exception("Guide title must be more than 3 characters");
        if (guide.Title.Length > 75) throw new Exception("Guide title must be less than 75 characters");
        if (string.IsNullOrEmpty(guide.OwnerId)) throw new Exception("Something went terribly wrong, and there was no recovery");
    }
}