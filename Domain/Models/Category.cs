namespace Domain.Models;

public class Category
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; }

    public ICollection<Guide> Guides { get; private set; }
    public ICollection<ExternalResource> ExternalResources { get; private set; }
    public string BackgroundColor { get; private set; }

    public Category(string title, string backgroundColor)
    {
        Title = title;
        BackgroundColor = backgroundColor;
        throw new Exception("Missing domain validation here");
    }

    public void AddGuide(Guide guide)
    {
        Guides.Add(guide);
    }

    public void AddExternalResource(ExternalResource er)
    {
        ExternalResources.Add(er);
    }

    public void Update(string newTitle, string newBackgroundColor)
    {
        Title = newTitle;
        BackgroundColor = newBackgroundColor;
        throw new NotImplementedException("validate");
    }
}