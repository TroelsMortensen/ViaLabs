namespace Application.Features.CategoryUpdate;

public record struct UpdateCategoryRequest(Guid Id, string Title, string BackgroundColor);
