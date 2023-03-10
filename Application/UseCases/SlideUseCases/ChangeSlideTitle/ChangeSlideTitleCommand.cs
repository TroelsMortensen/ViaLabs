namespace Application.UseCases.SlideUseCases.ChangeSlideTitle;

public record ChangeSlideTitleCommand(Guid GuideId, Guid StepId, string Title);