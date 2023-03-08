namespace Application.UseCases.GuideUseCases.ChangeGuideTitle;

public record ChangeGuideTitleCommand(Guid GuideId, string NewTitle);
