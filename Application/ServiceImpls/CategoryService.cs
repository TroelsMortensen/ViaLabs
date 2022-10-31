﻿using Application.DTOs.CategoryDTOs;
using Application.RepositoryContracts;
using Application.ServiceContracts;
using Domain.Models;

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

        try
        {
            await repoUow.BeginAsync();
            Category created = await repoUow.CategoryRepo.CreateAsync(newCat);
            await repoUow.SaveChangesAsync();
            return new CategoryDto(created.Id, created.Title, created.BackgroundColor);
        }
        catch (Exception e)
        {
            await repoUow.RollbackAsync();
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
            await repoUow.BeginAsync();
            await repoUow.CategoryRepo.UpdateAsync(categoryToUpdate);
            await repoUow.SaveChangesAsync();
        }
        catch (Exception e)
        {
            await repoUow.RollbackAsync();
            throw;
        }
    }

    public async Task DeleteAsync(Guid categoryId)
    {
        try
        {
            // TODO this should just happen in repository, because after when EFC I'll do on cascade delete.
            await repoUow.BeginAsync();
            await repoUow.GuideRepo.UnParentGuidesFromCategory(categoryId);
            await repoUow.ExternalResourceRepo.UnParentResourcesFromCategory(categoryId);
            await repoUow.CategoryRepo.DeleteAsync(categoryId);
            await repoUow.SaveChangesAsync();
        }
        catch (Exception e)
        {
            await repoUow.RollbackAsync();
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

        ICollection<Category> existing = await repoUow.CategoryRepo.GetCategoriesByTeacherAsync(category.OwnerId);
        Category? existingCategory = existing.FirstOrDefault(c => c.Title.Equals(category.Title, StringComparison.OrdinalIgnoreCase));
        if (existingCategory != null)
        {
            throw new ArgumentException("Category name already in use");
        }
    }
}