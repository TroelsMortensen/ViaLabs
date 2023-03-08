using Domain.Entities;

namespace Application.RepositoryContracts;

public interface ISlideContentRepo
{
    Task CreateAsync(SlideContent slideContent);
    Task<Slide> GetAsync(Guid slideContentId);
}