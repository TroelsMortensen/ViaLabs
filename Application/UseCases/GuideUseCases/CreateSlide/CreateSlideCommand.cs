namespace Application.UseCases.GuideUseCases.CreateSlide;

public record CreateSlideCommand(Guid GuideId, Guid SlideId, int StepIndex);