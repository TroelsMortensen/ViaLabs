using Entities;

namespace Application.EntryContracts;

public interface IGuideHome
{
    public Task CreateGuide(Guide guide);
}