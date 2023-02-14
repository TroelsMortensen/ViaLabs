namespace Application.CommandUseCases.CategoryHandlers.CategoryUpdate;

public record struct UpdateCategoryCommand(Guid Id, string Title, string BackgroundColor);
