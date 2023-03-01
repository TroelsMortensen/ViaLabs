namespace Application.UseCases.GuideUseCases.ChangeDescription;

public record ChangeGuideDescriptionCommand(Guid GuideId, string Description);