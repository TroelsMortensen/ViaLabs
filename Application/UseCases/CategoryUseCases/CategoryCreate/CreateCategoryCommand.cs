namespace Application.UseCases.CategoryUseCases.CategoryCreate;

public record CreateCategoryCommand(string Title, string OwningTeacher, string BackgroundColor, Guid Id);
