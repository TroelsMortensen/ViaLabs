namespace Entities;

public class Guide
{
    public Guid OwnerId { get; set; }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public bool IsPublished { get; set; }
    public bool DisplayStepNums { get; set; }

    public Guid CategoryId { get; set; }

}