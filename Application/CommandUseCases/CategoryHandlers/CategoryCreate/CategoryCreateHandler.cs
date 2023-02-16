using Application.HandlerContracts;
using Application.RepositoryContracts;
using Domain.Entities;
using Domain.OperationResult;

namespace Application.CommandUseCases.CategoryHandlers.CategoryCreate;

public class CategoryCreateHandler : ICommandHandler<CreateCategoryCommand, Guid>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly ICategoryRepo categoryRepo;

    public CategoryCreateHandler(IUnitOfWork unitOfWork, ICategoryRepo categoryRepo)
    {
        this.unitOfWork = unitOfWork;
        this.categoryRepo = categoryRepo;
    }

    public async Task<Result<Guid>> Handle(CreateCategoryCommand command)
    {
        Result<Category> newCatResult = Category.Create(command.Title, command.BackgroundColor, command.OwningTeacher);
        
        if (newCatResult.HasErrors)
            return Result.Failure<Guid>(newCatResult.Errors);

        Category category = newCatResult.Value;
        await categoryRepo.AddAsync(category);
        await unitOfWork.SaveChanges();
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