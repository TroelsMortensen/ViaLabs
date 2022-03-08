using Entities;

namespace Application.Repositories;

public interface IGuideRepo
{
    Task CreateAsync(Guide guide);
    Task<ICollection<Guide>> GetGuidesByCategoryIdAsync(Guid categoryId);
}