namespace Application.UseCases.GuideUseCases.ChangeSlideOrder;

public record MoveSlideUpCommand(Guid GuideId, Guid SlideId);