using Application.DTOs;
using Application.EntryContracts;
using Application.Repositories;
using Entities;

namespace Application.HomeImpls;

public class CategoryHome : ICategoryHome
{
    private ICategoryRepo categoryRepo;

    public CategoryHome(ICategoryRepo categoryRepo)
    {
        this.categoryRepo = categoryRepo;
    }

    public async Task<Category> CreateCategoryAsync(Category category)
    {
        await ValidateNewCategoryAsync(category);
        return await categoryRepo.CreateAsync(category);
    }

    private async Task ValidateNewCategoryAsync(Category category)
    {
        if (string.IsNullOrEmpty(category.Title)) throw new ArgumentException("Title cannot be empty");
        if (category.Title.Length < 3) throw new ArgumentException("Title must be 3 or more characters");
        if (category.Title.Length > 15) throw new ArgumentException("Title must be 15 or fewer characters");

        Category? existing = await categoryRepo.GetCategoryByTitleAndTeacherAsync(category.Title, category.Owner.Name);
        if (existing != null)
        {
            throw new ArgumentException("Category name already in use");
        }
    }
}