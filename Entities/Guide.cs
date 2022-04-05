namespace Entities;

public class Guide
{
    public string OwnerId { get; set; }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public bool IsPublished { get; set; }
    public bool DisplayStepNums { get; set; }

    public Guid? CategoryId { get; set; }

    public void Update(Guide guide)
    {
        Title = guide.Title;
        IsPublished = guide.IsPublished;
        DisplayStepNums = guide.DisplayStepNums;
        CategoryId = guide.CategoryId;
    }
}