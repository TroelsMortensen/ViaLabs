using Entities;

namespace Application.EntryContracts;

public interface IGuideHome
{
    public Task CreateGuideAsync(Guide guide);
    Task<ICollection<Guide>> GetGuidesByCategoryIdAsync(Guid categoryId);
}