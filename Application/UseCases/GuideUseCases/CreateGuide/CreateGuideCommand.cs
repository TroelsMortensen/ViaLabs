namespace Application.UseCases.GuideUseCases.CreateGuide;

public record CreateGuideCommand(Guid GuideId, Guid CategoryId, string Title, string TeacherName);