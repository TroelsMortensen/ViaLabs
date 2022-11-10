namespace Domain.Models;

public class ExternalResource
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; }
    public string Url { get; private set; }
    public string? Description { get; private set; }

    public ExternalResource(string title, string url)
    {
        Title = title;
        Url = url;
        throw new Exception("TODO: Missing domain validation here");
    }

    public void SetDescription(string desc)
    {
        throw new Exception("TODO: Missing domain validation here");
        Description = desc;
    }

    public void Update(string editedTitle, string? editedDescription, string editedUrl)
    {
        Title = editedTitle;
        Description = editedDescription;
        Url = editedUrl;
        throw new Exception("TODO: Missing domain validation here");
    }
}