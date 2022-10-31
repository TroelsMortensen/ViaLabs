namespace Domain.Models;

public class Category
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }

    public string OwnerId { get; private set; }
    public string BackgroundColor { get; private set; }

    public Category(string title, string ownerId, string backgroundColor)
    {
        Title = title;
        OwnerId = ownerId;
        BackgroundColor = backgroundColor;
        throw new Exception("Missing domain validation here");
    }
}