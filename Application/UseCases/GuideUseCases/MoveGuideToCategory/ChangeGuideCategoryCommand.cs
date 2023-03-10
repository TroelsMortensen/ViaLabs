namespace Application.UseCases.GuideUseCases.MoveGuideToCategory;

public record ChangeGuideCategoryCommand(Guid GuideId, Guid CategoryId);
