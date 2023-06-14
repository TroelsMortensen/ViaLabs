using Application.HandlerContracts;
using Application.RepositoryContracts;
using Domain.Aggregates;
using Domain.OperationResult;
using Domain.Values;

namespace Application.UseCases.CategoryUseCases.CategoryCreate;

public class CategoryCreateHandler : ICommandHandler<CreateCategoryCommand>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly ICategoryRepo categoryRepo;

    public CategoryCreateHandler(IUnitOfWork unitOfWork, ICategoryRepo categoryRepo)
    {
        this.unitOfWork = unitOfWork;
        this.categoryRepo = categoryRepo;
    }

    public async Task<Result> Handle(CreateCategoryCommand command)
    {
        Result<Category> newCatResult = Category.Create(command.Title, command.BackgroundColor, command.OwningTeacher, CategoryId.FromString(command.Id.ToString()));
        
        if (newCatResult.HasErrors)
            return Result.Failure(newCatResult.Errors);

        Category category = newCatResult.Value;
        await categoryRepo.AddAsync(category);
        await unitOfWork.SaveChangesAsync();
        // CategoryDto categoryDto = new(category.Id, category.Title, category.BackgroundColor);
        
        return Result.Success(category.Id);
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