using Application.Features.ProfileDataLogic.DTOs.CategoryDTOs;
using Application.Features.ProfileDataLogic.LogicContracts;
using Application.RepositoryContracts;
using Domain.Models;

namespace Application.Features.ProfileDataLogic.LogicImpls;

public class CategoryLogic : ICategoryLogic
{
    private readonly IRepoManager repoManager;

    public CategoryLogic(IRepoManager repoManager)
    {
        this.repoManager = repoManager;
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

        try
        {
            await repoManager.BeginAsync();
            Category created = await repoManager.CategoryRepo.CreateAsync(newCat);
            await repoManager.SaveChangesAsync();
            return new CategoryDto(created.Id, created.Title, created.BackgroundColor);
        }
        catch (Exception e)
        {
            await repoManager.RollbackAsync();
            throw;
        }
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
        try
        {
            await repoManager.BeginAsync();
            await repoManager.CategoryRepo.UpdateAsync(categoryToUpdate);
            await repoManager.SaveChangesAsync();
        }
        catch (Exception e)
        {
            await repoManager.RollbackAsync();
            throw;
        }
    }

    public async Task DeleteAsync(Guid categoryId)
    {
        try
        {
            // TODO this should just happen in repository, because after when EFC I'll do on cascade delete.
            await repoManager.BeginAsync();
            await repoManager.GuideRepo.UnParentGuidesFromCategory(categoryId);
            await repoManager.ExternalResourceRepo.UnParentResourcesFromCategory(categoryId);
            await repoManager.CategoryRepo.DeleteAsync(categoryId);
            await repoManager.SaveChangesAsync();
        }
        catch (Exception e)
        {
            await repoManager.RollbackAsync();
            throw;
        }
    }

    private static void ValidateNewCategoryData(Category category)
    {
        if (string.IsNullOrEmpty(category.Title)) throw new ArgumentException("Title cannot be empty");
        if (category.Title.Length < 3) throw new ArgumentException("Title must be 3 or more characters");
        if (category.Title.Length > 25) throw new ArgumentException("Title must be 25 or fewer characters");
    }

    private async Task ValidateTitleIsFree(Category category)
    {
        // TODO should probably change this? Currently multiple teachers can have the same category.

        ICollection<Category> existing = await repoManager.CategoryRepo.GetCategoriesByTeacherAsync(category.OwnerId);
        Category? existingCategory = existing.FirstOrDefault(c => c.Title.Equals(category.Title, StringComparison.OrdinalIgnoreCase));
        if (existingCategory != null)
        {
            throw new ArgumentException("Category name already in use");
        }
    }
}