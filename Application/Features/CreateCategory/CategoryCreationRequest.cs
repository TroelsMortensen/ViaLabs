namespace Application.Features.CreateCategory;

public record struct CategoryCreationRequest(string Title, string OwningTeacher, string BackgroundColor);
