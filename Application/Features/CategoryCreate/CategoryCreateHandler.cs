using Application.Features.SharedDtos;
using Application.RepositoryContracts;
using Domain.Entities;
using SharedKernel.OperationResult;

namespace Application.Features.CategoryCreate;

public class CategoryCreateHandler : ICategoryCreateHandler
{
    private readonly IUnitOfWork unitOfWork;
    private readonly ICategoryRepo categoryRepo;

    public CategoryCreateHandler(IUnitOfWork unitOfWork, ICategoryRepo categoryRepo)
    {
        this.unitOfWork = unitOfWork;
        this.categoryRepo = categoryRepo;
    }

    public async Task<Result<CategoryDto>> CreateAsync(CategoryCreateRequest request)
    {
        // bool categoryIsFree = await ValidateTitleIsFree(request.Title);

        // if (categoryIsFree)
        //     return new("Category.Title", "Category title already in use");

        Result<Category> newCatResult = Category.Create(request.Title, request.BackgroundColor, request.OwningTeacher);
        if (newCatResult.HasErrors)
            return new Result<CategoryDto>(newCatResult.Errors);

        Category category = newCatResult.Value;
        await categoryRepo.AddAsync(category);

        CategoryDto categoryDto = new(category.Id, category.Title, category.BackgroundColor);

        throw new Exception("Never return data from handlers");
        return new(categoryDto);
    }

    // private async Task<bool> ValidateTitleIsFree(string categoryTitle, string teacherName)
    // {
    //     Teacher teacher = await unitOfWork.TeacherRepo.GetApprovedTeacher(teacherName);
    //
    //     IEnumerable<Category> teachersCategories = teacher.Categories;
    //     Category? existingCategory =
    //         unitOfWork.CategoryRepo.FirstOrDefault(c => c.Title.Equals(categoryTitle, StringComparison.OrdinalIgnoreCase));
    //
    //     return existingCategory != null;
    // }
}