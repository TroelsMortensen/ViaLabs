namespace Entities;

public class Guide
{
    public Teacher Owner { get; }
    public Guid Id { get; } = Guid.NewGuid();
    public string Title { get; set; } = String.Empty;
    public bool IsPublished { get; set; }
    public bool IncludeStepNums { get; set; }
    public Category? Category { get; set; }

    public Guide(Teacher owner)
    {
        Owner = owner;
    }
}