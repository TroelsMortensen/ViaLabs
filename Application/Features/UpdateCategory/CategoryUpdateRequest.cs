namespace Application.Features.UpdateCategory;

public record struct CategoryUpdateRequest(Guid Id, string Title, string BackgroundColor);
