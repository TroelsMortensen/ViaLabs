namespace Application.UseCases.SlideUseCases.CreateSlide;

public record CreateSlideCommand(Guid GuideId, Guid SlideId, int StepIndex);