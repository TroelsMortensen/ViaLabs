namespace Domain.Models;

public class Guide
{
    public string OwnerId { get; private set; }
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public bool IsPublished { get; private set; }
    public bool DisplayStepNums { get; private set; }

    public Guid? CategoryId { get; private set; }

    public void Update(Guide guide)
    {
        Title = guide.Title;
        IsPublished = guide.IsPublished;
        DisplayStepNums = guide.DisplayStepNums;
        CategoryId = guide.CategoryId;
        throw new Exception("Missing domain validation here");
    }
}