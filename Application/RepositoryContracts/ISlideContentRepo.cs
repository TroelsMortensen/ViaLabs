using Domain.Entities;

namespace Application.RepositoryContracts;

public interface ISlideContentRepo
{
    Task CreateAsync(SlideContent slideContent);
    Task<SlideStep> GetAsync(Guid slideContentId);
}