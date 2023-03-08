namespace Application.UseCases.GuideUseCases.ChangeSlideTitle;

public record ChangeSlideTitleCommand(Guid GuideId, Guid StepId, string Title);