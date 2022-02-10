namespace Entities;

public class Guide
{
    public Teacher Owner { get; }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public bool IsPublished { get; set; }
    public bool IncludeStepNums { get; set; }
    public Category? Category { get; set; }

    public Guide(Teacher owner, string title)
    {
        Owner = owner;
        Title = title;
    }
}