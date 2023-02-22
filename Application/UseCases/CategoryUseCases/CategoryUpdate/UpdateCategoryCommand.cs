namespace Application.UseCases.CategoryUseCases.CategoryUpdate;

public record struct UpdateCategoryCommand(Guid Id, string Title, string BackgroundColor);
