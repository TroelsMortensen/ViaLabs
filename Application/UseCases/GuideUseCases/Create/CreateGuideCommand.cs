namespace Application.UseCases.GuideUseCases.Create;

public record CreateGuideCommand(Guid GuideId, Guid CategoryId, string Title, string TeacherName);