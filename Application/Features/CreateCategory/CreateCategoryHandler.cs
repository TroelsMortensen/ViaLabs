using Application.Features.SharedDtos;
using Application.RepositoryContracts;
using Domain.Models;
using SharedKernel.Results;

namespace Application.Features.CreateCategory;

public class CreateCategoryHandler : ICreateCategoryHandler
{
    private readonly IRepoManager repoManager;

    public CreateCategoryHandler(IRepoManager repoManager)
    {
        this.repoManager = repoManager;
    }

    public async Task<Result<CategoryDto>> CreateAsync(CreateCategoryRequest request)
    {
        bool categoryIsFree = await ValidateTitleIsFree(request.Title, request.OwningTeacher);

        if (categoryIsFree)
            return new("Category.Title", "Category title already in use");

        Result<Category> newCatResult = Category.Create(request.Title, request.BackgroundColor);
        if (newCatResult.HasErrors)
            return new Result<CategoryDto>(newCatResult.Errors);

        Category created = await repoManager.CategoryRepo.AddToTeacher(newCatResult.Value, request.OwningTeacher);

        CategoryDto categoryDto = new(created.Id, created.Title, created.BackgroundColor);

        return new(categoryDto);
    }

    private async Task<bool> ValidateTitleIsFree(string categoryTitle, string teacherName)
    {
        Teacher teacher = await repoManager.TeacherRepo.GetApprovedTeacher(teacherName);

        IEnumerable<Category> teachersCategories = teacher.Categories;
        Category? existingCategory =
            teachersCategories.FirstOrDefault(c => c.Title.Equals(categoryTitle, StringComparison.OrdinalIgnoreCase));

        return existingCategory != null;
    }
}