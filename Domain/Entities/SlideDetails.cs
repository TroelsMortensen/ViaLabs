namespace Domain.Entities;

public class SlideDetails
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; }
    
    public int StepNumber { get; private set; }
    
    public Guid SlideContentId { get; private set; }

    private SlideDetails() // json/ efc
    {
    }

}