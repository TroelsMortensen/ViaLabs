using Entities;

namespace Application.RepositoryContracts;

public interface ICategoryRepo
{
    Task<Category> CreateAsync(Category category);
    Task<ICollection<Category>> GetCategoriesByTeacherAsync(string teacherId);
    Task UpdateAsync(Category categoryToUpdate);
    Task DeleteAsync(Guid categoryId);
}