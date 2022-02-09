using Entities;

namespace Application.Repositories;

public interface ICategoryRepo
{
    Task CreateAsync(Category category);
}