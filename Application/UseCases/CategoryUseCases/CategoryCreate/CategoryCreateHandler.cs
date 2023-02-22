using Application.HandlerContracts;
using Application.RepositoryContracts;
using Domain.OperationResult;

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
        Result<Domain.Entities.Category> newCatResult = Domain.Entities.Category.Create(command.Title, command.BackgroundColor, command.OwningTeacher, command.Id);
        
        if (newCatResult.HasErrors)
            return Result.Failure(newCatResult.Errors);

        Domain.Entities.Category category = newCatResult.Value;
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