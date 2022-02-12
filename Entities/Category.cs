namespace Entities;

public class Category
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    public Teacher Owner { get; set; }
    public string BackgroundColor { get; set; }
}