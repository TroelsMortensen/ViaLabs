namespace Application.UseCases.GuideUseCases.GuideCreate;

public record CreateGuideCommand(Guid GuideId, Guid CategoryId, string Title, string TeacherName);