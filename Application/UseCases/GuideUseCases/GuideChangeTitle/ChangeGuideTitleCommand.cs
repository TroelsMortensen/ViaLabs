namespace Application.UseCases.GuideUseCases.GuideChangeTitle;

public record ChangeGuideTitleCommand(Guid GuideId, string NewTitle);
