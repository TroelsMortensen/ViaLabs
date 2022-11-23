using Domain.Models;

namespace Application.RepositoryContracts;

public interface ICategoryRepo
{
    Task<Category> AddToTeacher(Category category, string teacherName);
    Task<IEnumerable<Category>> GetCategoriesByTeacherAsync(string teacherId);
    Task UpdateAsync(Category categoryToUpdate);
    Task DeleteAsync(Guid categoryId);
    Task<Category> GetCategoryById(Guid id);
}