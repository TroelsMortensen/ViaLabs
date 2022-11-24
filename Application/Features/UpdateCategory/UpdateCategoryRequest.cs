namespace Application.Features.UpdateCategory;

public record struct UpdateCategoryRequest(Guid Id, string Title, string BackgroundColor);
