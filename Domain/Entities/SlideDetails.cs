using Domain.OperationResult;

namespace Domain.Entities;

public class SlideDetails
{
    public Guid Id { get; private set; }
    public string? Title { get; private set; }
    
    public int StepNumber { get; private set; }


    public Guid SlideContentId { get; private set; }

    private SlideDetails() // json / efc
    {
    }

    private SlideDetails(Guid slideId, int slideIndex, Guid slideContentId)
    {
        Id = slideId;
        StepNumber = slideIndex;
        SlideContentId = slideContentId;
    }

    public static SlideDetails Create(Guid slideId, int slideIndex, Guid slideContentId)
    {
        return new SlideDetails(slideId, slideIndex, slideContentId);
    }
}