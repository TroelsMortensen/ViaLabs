namespace Domain.Models;

public class ExternalResource
{
    public Guid Id { get; private set; }
    public string OwnerId { get; private set; }
    public string Title { get; private set; }
    public string Url { get; private set; }
    public string? Description { get; private set; }
    public Guid? CategoryId { get; private set; }

    public ExternalResource(string ownerId, string title, string url)
    {
        OwnerId = ownerId;
        Title = title;
        Url = url;
        throw new Exception("Missing domain validation here");
    }

    public void DetachFromCategory()
    {
        CategoryId = null;
    }
}