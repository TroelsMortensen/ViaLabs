using Application.Profile.DTOs;
using Entities;

namespace Application.Repositories;

public interface ICategoryRepo
{
    Task<Category> CreateAsync(Category category);
    Task<ICollection<Category>> GetCategoriesByTeacherAsync(string teacherId);
    Task UpdateAsync(Category categoryToUpdate);
}