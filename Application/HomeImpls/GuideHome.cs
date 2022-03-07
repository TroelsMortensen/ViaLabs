using Application.EntryContracts;
using Application.Repositories;
using Entities;

namespace Application.HomeImpls;

public class GuideHome : IGuideHome
{
    private IGuideRepo guideRepo;

    public GuideHome(IGuideRepo guideRepo)
    {
        this.guideRepo = guideRepo;
    }

    public Task CreateGuide(Guide guide)
    {
        throw new NotImplementedException();
    }
}