using Entities;

namespace Application.EntryContracts;

public interface IGuideService
{
    public Task<Guide> CreateGuideAsync(Guide guide);
    Task<ICollection<Guide>> GetGuidesByCategoryIdAsync(Guid categoryId);
    Task<ICollection<Guide>> GetUnCategorizedByTeacherAsync(string teacher);
}