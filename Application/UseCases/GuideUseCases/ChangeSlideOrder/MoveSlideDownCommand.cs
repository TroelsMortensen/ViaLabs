namespace Application.UseCases.GuideUseCases.ChangeSlideOrder;

public record MoveSlideDownCommand(Guid GuideId, Guid SlideId);