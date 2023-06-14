using Domain.Aggregates;

namespace Application.RepositoryContracts;

public interface IGuideRepo
{
    Task CreateAsync(Guide guide);

    Task<Guide> GetAsync(Guid id);
    // Task UpdateAsync(Guide guide);
    Task DeleteAsync(Guid id);
    Task<ICollection<Guide>> GetByCategoryAsync(Guid id);
}