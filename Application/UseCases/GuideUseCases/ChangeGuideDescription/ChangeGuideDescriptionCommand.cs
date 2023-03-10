namespace Application.UseCases.GuideUseCases.ChangeGuideDescription;

public record ChangeGuideDescriptionCommand(Guid GuideId, string Description);