namespace Domain.Entities;

public class SlideStep
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    
    public int StepIndex { get; private set; }


    public Guid SlideContentId { get; private set; }

    private SlideStep() // json / efc
    {
    }

    private SlideStep(Guid slideId, int slideIndex, Guid slideContentId)
    {
        Id = slideId;
        StepIndex = slideIndex;
        SlideContentId = slideContentId;
        Title = "";
    }

    public static SlideStep Create(Guid slideId, int slideIndex, Guid slideContentId)
    {
        return new SlideStep(slideId, slideIndex, slideContentId);
    }
}