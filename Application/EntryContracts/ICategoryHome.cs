using Application.DTOs;
using Entities;

namespace Application.EntryContracts;

public interface ICategoryHome
{
    public Task<Category> CreateCategoryAsync(Category category);
    Task<CategoriesWithGuidesOverviewDto> GetCategoriesWithGuidesOverviewByUserAsync(string teacherName);
}