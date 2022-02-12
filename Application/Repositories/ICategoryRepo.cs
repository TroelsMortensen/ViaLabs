using Entities;

namespace Application.Repositories;

public interface ICategoryRepo
{
    Task<Category> CreateAsync(Category category);
    Task<Category?> GetCategoryByTitleAndTeacherAsync(string categoryTitle, string ownerName);
}