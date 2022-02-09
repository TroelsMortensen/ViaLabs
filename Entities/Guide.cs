namespace Entities;

public class Guide
{
    public Teacher Owner { get; set; }
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; set; }
    public bool IsPublished { get; set; }
    public bool IncludeStepNums { get; set; }
}