using Domain.OperationResult;

namespace Domain.Entities;

public class Slide
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    
    public int StepIndex { get; private set; }


    public Guid SlideContentId { get; private set; }

    private Slide() // json / efc
    {
    }

    private Slide(Guid slideId, int slideIndex, Guid slideContentId)
    {
        Id = slideId;
        StepIndex = slideIndex;
        SlideContentId = slideContentId;
        Title = "";
    }

    public static Slide Create(Guid slideId, int slideIndex, Guid slideContentId)
    {
        return new Slide(slideId, slideIndex, slideContentId);
    }

    public void PushStepDown()
    {
        StepIndex++;
    }

    public Result ChangeTitle(string title)
    {
        if (title == null)
        {
            Title = "";
            return Result.Success();
        }

        if (title.Length > 30)
        {
            return Result.Failure("Guide.Slide.Title", "Slide title must be less than 30 characters.");
        }

        Title = title;
        return Result.Success();
    }
}