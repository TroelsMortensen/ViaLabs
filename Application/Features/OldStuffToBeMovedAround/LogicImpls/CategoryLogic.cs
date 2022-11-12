using Application.Features.ProfileDataLogic.DTOs.CategoryDTOs;
using Application.Features.ProfileDataLogic.LogicContracts;
using Application.RepositoryContracts;
using Domain.Exceptions;
using Domain.Models;

namespace Application.Features.ProfileDataLogic.LogicImpls;

public class CategoryLogic : ICategoryLogic
{
    private readonly IRepoManager repoManager;

    public CategoryLogic(IRepoManager repoManager)
    {
        this.repoManager = repoManager;
    }

    public async Task<CategoryDto> CreateAsync(CategoryCreationRequest request)
    {
        await ValidateTitleIsFree(request.Title, request.OwningTeacher);

        Category newCat = new(request.Title, request.BackgroundColor);

        ValidateNewCategoryData(newCat);

        Category created = await repoManager.CategoryRepo.AddToTeacher(newCat, request.OwningTeacher);
        CategoryDto categoryDto = new(created.Id, created.Title, created.BackgroundColor);

        return categoryDto;
    }

    public async Task UpdateAsync(CategoryDto toUpdate)
    {
        Category catBeingUpdated = await repoManager.CategoryRepo.GetCategoryById(toUpdate.Id);
        catBeingUpdated.Update(toUpdate.Title, toUpdate.BackgroundColor);

        ValidateNewCategoryData(catBeingUpdated);

        await repoManager.CategoryRepo.UpdateAsync(catBeingUpdated);
    }

    public async Task DeleteAsync(Guid categoryId)
    {
        // cannot delete something which has resources. Do not do cascade.

        throw new NotImplementedException("Mangler her");

        await repoManager.CategoryRepo.DeleteAsync(categoryId);
    }

    private static void ValidateNewCategoryData(Category category)
    {
        DataValidationException exception = new();

        if (string.IsNullOrEmpty(category.Title))
        {
            exception.AddError("Title cannot be empty");
        }

        if (category.Title.Length < 3)
        {
            exception.AddError("Title must be 3 or more characters");
        }

        if (category.Title.Length > 25)
        {
            exception.AddError("Title must be less than 25 characters");
        }

        exception.ThrowIfErrors();
    }

    private async Task ValidateTitleIsFree(string categoryTitle, string teacherName)
    {
        DataValidationException exception = new();

        ICollection<Category> existing = await repoManager.CategoryRepo.GetCategoriesByTeacherAsync(teacherName);
        Category? existingCategory = existing.FirstOrDefault(c => c.Title.Equals(categoryTitle, StringComparison.OrdinalIgnoreCase));

        if (existingCategory != null)
        {
            exception.AddError("Category name already in use");
        }
        exception.ThrowIfErrors();
    }
}