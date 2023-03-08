namespace Application.UseCases.GuideUseCases.ChangeStepTitle;

public record ChangeSlideTitleCommand(Guid GuideId, Guid StepId, string Title);