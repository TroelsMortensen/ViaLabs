namespace Application.UseCases.GuideUseCases.ChangeTitle;

public record ChangeGuideTitleCommand(Guid GuideId, string NewTitle);
