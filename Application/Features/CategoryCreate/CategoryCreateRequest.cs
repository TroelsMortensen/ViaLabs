namespace Application.Features.CategoryCreate;

public record struct CategoryCreateRequest(string Title, string OwningTeacher, string BackgroundColor);
