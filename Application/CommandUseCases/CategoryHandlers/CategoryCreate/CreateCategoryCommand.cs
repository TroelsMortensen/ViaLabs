namespace Application.CommandUseCases.CategoryHandlers.CategoryCreate;

public record struct CreateCategoryCommand(string Title, string OwningTeacher, string BackgroundColor);
