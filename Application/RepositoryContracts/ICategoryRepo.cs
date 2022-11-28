using Domain.Entities;

namespace Application.RepositoryContracts;

public interface ICategoryRepo
{
    Task<Category> AddToTeacherAsync(Category category, string teacherName);
    Task<IEnumerable<Category>> GetCategoriesByTeacherAsync(string teacherId);
    Task UpdateAsync(Category categoryToUpdate);
    Task DeleteAsync(Guid categoryId);
    Task<Category> GetCategoryByIdAsync(Guid id);
}