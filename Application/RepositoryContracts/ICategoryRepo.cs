using Domain.Entities;

namespace Application.RepositoryContracts;

public interface ICategoryRepo
{
    Task AddAsync(Category category);
    // Task UpdateAsync(Category categoryToUpdate);
    Task DeleteAsync(Guid categoryId);
    Task<Category> GetAsync(Guid id);

    Task<IEnumerable<Category>> GetCategoriesByTeacherAsync(string teacherName);
}