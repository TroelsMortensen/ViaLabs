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

    public async Task<CategoryDto> CreateAsync(CategoryCreationDto dto)
    {
        Category newCat = new(dto.Title, dto.OwnerId, dto.BackgroundColor);
        await ValidateTitleIsFree(newCat);

        ValidateNewCategoryData(newCat);

        Category created = await repoManager.CategoryRepo.CreateAsync(newCat);
        return new CategoryDto(created.Id, created.Title, created.BackgroundColor);
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
        // TODO this should just happen in repository, because after when EFC I'll do on cascade delete.
        await repoManager.GuideRepo.UnParentGuidesFromCategory(categoryId);
        await repoManager.ExternalResourceRepo.UnParentResourcesFromCategory(categoryId);
        await repoManager.CategoryRepo.DeleteAsync(categoryId);
    }

    private static void ValidateNewCategoryData(Category category)
    {
        // TODO create InValidDataException med list af errors
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