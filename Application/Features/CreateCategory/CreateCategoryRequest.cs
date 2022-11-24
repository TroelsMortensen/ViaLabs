namespace Application.Features.CreateCategory;

public record struct CreateCategoryRequest(string Title, string OwningTeacher, string BackgroundColor);
