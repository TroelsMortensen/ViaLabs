using Application.DTOs.CategoryDTOs;
using Application.RepositoryContracts;
using Application.ServiceContracts;
using Entities;

namespace Application.ServiceImpls;

public class CategoryService : ICategoryService
{
    private readonly IRepoUOW repoUow;

    public CategoryService(IRepoUOW repoUow)
    {
        this.repoUow = repoUow;
    }

    public async Task<CategoryDto> CreateAsync(CategoryCreationDto category)
    {
        Category newCat = new()
        {
            Id = Guid.NewGuid(),
            Title = category.Title,
            BackgroundColor = category.BackgroundColor,
            OwnerId = category.OwnerId
        };
        ValidateNewCategoryData(newCat);
        await ValidateTitleIsFree(newCat);
        
        Category created = await repoUow.CategoryRepo.CreateAsync(newCat);
        await repoUow.SaveChangesAsync();
        
        return new CategoryDto
        {
            Id = created.Id,
            Title = created.Title,
            BackgroundColor = created.BackgroundColor
        };
    }

    public async Task UpdateAsync(CategoryDto toUpdate)
    {
        Category categoryToUpdate = new()
        {
            Id = toUpdate.Id,
            Title = toUpdate.Title,
            BackgroundColor = toUpdate.BackgroundColor,
        };
        ValidateNewCategoryData(categoryToUpdate);
        await repoUow.CategoryRepo.UpdateAsync(categoryToUpdate);
        await repoUow.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid categoryId)
    {
        await repoUow.CategoryRepo.DeleteAsync(categoryId);
        await repoUow.SaveChangesAsync();
    }

    private static void ValidateNewCategoryData(Category category)
    {
        if (string.IsNullOrEmpty(category.Title)) throw new ArgumentException("Title cannot be empty");
        if (category.Title.Length < 3) throw new ArgumentException("Title must be 3 or more characters");
        if (category.Title.Length > 25) throw new ArgumentException("Title must be 25 or fewer characters");
    }

    private async Task ValidateTitleIsFree(Category category)
    {
        ICollection<Category> existing = await repoUow.CategoryRepo.GetCategoriesByTeacherAsync(category.OwnerId);
        Category? existingCategory = existing.FirstOrDefault(c => c.Title.Equals(category.Title, StringComparison.OrdinalIgnoreCase));
        if (existingCategory != null)
        {
            throw new ArgumentException("Category name already in use");
        }
    }
}